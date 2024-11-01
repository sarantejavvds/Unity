using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ENEMY))]
public class Enemy_Health : MonoBehaviour
{
    public int Max_HitPoints = 5;

    [Tooltip("Add Amount to Max Hitpoints whenever Enemy Dies.")]
    public int Difficulty_RAMP = 1;

    int Current_HitPoints = 0;

    ENEMY enemy;

    void OnEnable()
    {
        Current_HitPoints = Max_HitPoints;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<ENEMY>();
    }

    void Kill_Enemy()
    {
        if(Current_HitPoints <= 0)
        {
            // Destroy(gameObject);

            gameObject.SetActive(false);

            Max_HitPoints += Difficulty_RAMP;

            enemy.Reward_Gold();
        }
    }

    void Process_Damage_Enemy()
    {
        Current_HitPoints--;

        Kill_Enemy();
    }

    private void OnParticleCollision(GameObject other)
    {
        Process_Damage_Enemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
