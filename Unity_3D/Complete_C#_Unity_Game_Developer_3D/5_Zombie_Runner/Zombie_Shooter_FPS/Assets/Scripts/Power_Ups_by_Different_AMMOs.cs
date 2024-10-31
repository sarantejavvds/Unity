using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Ups_by_Different_AMMOs : MonoBehaviour
{
    public int ammo_Amount = 5;

    public Different_AMMUNITIONS ammo_Type;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            FindObjectOfType<AMMO>().Increase_Current_AMMUNITIONs_by_picking_Power_UPs(ammo_Type, ammo_Amount);

            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
