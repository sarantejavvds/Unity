using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

public class ENEMY_AI : MonoBehaviour
{
    // public Transform target; // Gives HERO Player as target

    public float Chase_Range = 10; // if player enters this range, zombie will start chasing

    public float Rotation_Speed_of_Zombie = 5f;

    float Distance_To_Target = Mathf.Infinity; // Making Distance to the target is long for the zombie 

    NavMeshAgent navMeshAgent;

    Enemy_Health health;

    Transform target; // Let's make our Enemies find our HERO player Dynamically.

    bool isProvoked = false; // Checking if Zombie is provoked or not.

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        health = GetComponent<Enemy_Health>();

        target = FindObjectOfType<HERO_Health>().transform;
    }

    void Rotate_Zombie_to_HERO_Direction() 
    {
        Vector3 direction_of_hero = (target.position - transform.position).normalized;

        Quaternion look_Rotated_Direction = Quaternion.LookRotation(new Vector3(direction_of_hero.x, 0, direction_of_hero.z));

        transform.rotation = Quaternion.Slerp(transform.rotation, look_Rotated_Direction, Time.deltaTime * Rotation_Speed_of_Zombie);
    }

    void Chase_Target()
    {
        GetComponent<Animator>().SetBool("attack", false);

        GetComponent<Animator>().SetTrigger("move");

        navMeshAgent.SetDestination(target.position); // Chase the HERO with kill intentions
    }

    void Attack_Target()
    {
        GetComponent<Animator>().SetBool("attack", true);

        Debug.Log(name + " was Attacking " + target.name);
    }

    public void On_Damage_Taken()
    {        
        isProvoked = true;
    }

    void Engage_Target_to_Kill()
    {
        Rotate_Zombie_to_HERO_Direction();

        if(Distance_To_Target >= navMeshAgent.stoppingDistance) // if Zombie is far away from target when chasing.
        {
            Chase_Target();
        }
        if(Distance_To_Target <= navMeshAgent.stoppingDistance) // if Target is catched by zombie.
        {
            Attack_Target();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(health.Is_Enemy_Dead())
        {
            enabled = false;

            navMeshAgent.enabled = false;
        }
        else
        {
            Distance_To_Target = Vector3.Distance(target.position, transform.position); // Measuring the Distance between Hero and Zombie for every Frame of Update.
                                                                                        // HERO position  // Zombie Position

            if (isProvoked)
            {
                Engage_Target_to_Kill();
            }
            else if (Distance_To_Target <= Chase_Range) // Checking if the HERO is in near or far away Range to Chase by Zombie
            {
                isProvoked = true;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, Chase_Range);
    }
    
}
