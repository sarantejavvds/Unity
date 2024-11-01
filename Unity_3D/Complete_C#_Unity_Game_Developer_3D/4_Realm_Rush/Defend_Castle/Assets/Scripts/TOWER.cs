using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TOWER : MonoBehaviour
{
    public int Cost_to_Deploy_Ballista = 75;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool Create_Tower_Here(TOWER tower, Vector3 position)
    {
        Treasure_Bank bank = FindObjectOfType<Treasure_Bank>();

        if (bank == null)
        {
            return false;
        }
        if (bank.Current_Balance >= Cost_to_Deploy_Ballista)
        {
            Instantiate(tower, position, Quaternion.identity);

            bank.Withdraw_GOLD(Cost_to_Deploy_Ballista);

            return true;
        }

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
