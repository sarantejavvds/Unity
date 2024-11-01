using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY : MonoBehaviour
{
    public int GOLD_Reward = 25;

    public int GOLD_Penalty = 20;

    Treasure_Bank bank;

    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<Treasure_Bank>();
    }

    public void Reward_Gold()
    {
        if (bank == null)
        {
            return;
        }

        bank.Deposit_GOLD(GOLD_Reward);
    }
    
    public void Steal_Gold()
    {
        if (bank == null)
        {
            return;
        }

        bank.Withdraw_GOLD(GOLD_Penalty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
