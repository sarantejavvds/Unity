using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Locater : MonoBehaviour
{
    public Transform Weapon;

    public float Ballista_Range = 15f;

    public ParticleSystem projectiled_Bolts;

    Transform Target;

    void Find_Closest_Target()
    {
        ENEMY[] enemies = FindObjectsOfType<ENEMY>();

        Transform Closest_Target = null;

        float Max_Distance = Mathf.Infinity;

        foreach(ENEMY enemy in enemies)
        {
            float Target_Distance = Vector3.Distance(transform.position, enemy.transform.position);

            if(Target_Distance < Max_Distance)
            {
                Closest_Target = enemy.transform;

                Max_Distance = Target_Distance;
            }

        }

        Target = Closest_Target;
    }

    void Attack(bool isActive)
    {
        var emissionModule = projectiled_Bolts.emission;

        emissionModule.enabled = isActive;
    }

    void Weapon_Aim_for_Target()
    {
        float Target_Distance = Vector3.Distance(transform.position, Target.position);

        Weapon.LookAt(Target);

        if(Target_Distance < Ballista_Range)
        {
            Attack(true);
        }
        else 
        {
            Attack(false);
        }

    }


    // Start is called before the first frame update
    void Start()
    {
       // Target = FindObjectOfType<Enemy_Movement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Find_Closest_Target();

        Weapon_Aim_for_Target();
    }
}
