using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    [SerializeField] float Health_Points_of_Enemy = 100f;

    bool is_Enemy_Dead = false;

    public bool Is_Enemy_Dead()
    {
        return is_Enemy_Dead;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Zombie_Death()
    {
        if(is_Enemy_Dead)
        {
            return;
        }

        is_Enemy_Dead = true;

        GetComponent<Animator>().SetTrigger("die");

    }

    public void Damage_Taken_To_Zombie_From_Player_Weapon(float Damage_Received)
    {
        BroadcastMessage("On_Damage_Taken");

        Health_Points_of_Enemy -= Damage_Received;

        if(Health_Points_of_Enemy <= 0)
        {
            Debug.Log("Zombie Got Dead");

            //  Destroy(gameObject);

            Zombie_Death();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
