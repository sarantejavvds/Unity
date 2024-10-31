using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack_Event : MonoBehaviour
{
    HERO_Health hero_as_Target;

    public float Damage_from_Zombie = 25f;

    // Start is called before the first frame update
    void Start()
    {
        hero_as_Target = FindObjectOfType<HERO_Health>();
    }

    public void On_Damage_Taken()
    {
        Debug.Log(name + " I also known we took Damage");

        // isProvoked = true;
    }
    public void Attack_Hit_Event_from_Enemy()
    {
        if (hero_as_Target == null) 
        {
            return; 
        }

        hero_as_Target.Damage_Taken_by_HERO_from_Zombie_Attack(Damage_from_Zombie);

        hero_as_Target.GetComponent<Display_Blood_of_Player_when_Damage_Taken>().Show_Damage_Impact();

        Debug.Log("bang bang bang");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
