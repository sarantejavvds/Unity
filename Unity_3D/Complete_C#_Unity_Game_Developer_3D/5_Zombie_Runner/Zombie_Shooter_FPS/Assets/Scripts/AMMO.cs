using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMMO : MonoBehaviour
{
    [System.Serializable]
    private class AMMO_Slot
    {
        public Different_AMMUNITIONS ammo_Type;

        public int ammo_Amount;
    }

    [SerializeField] AMMO_Slot[] ammo_Slots; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private AMMO_Slot Get_AMMO_Slot_for_Each_Individual_Weapon(Different_AMMUNITIONS ammo_Type)
    {
        foreach (AMMO_Slot slot in ammo_Slots)
        {
            if(slot.ammo_Type == ammo_Type)
            {
                return slot;
            }
        }

        return null;
    }

    public int Get_Current_AMMO(Different_AMMUNITIONS ammo_Type)
    {
        return Get_AMMO_Slot_for_Each_Individual_Weapon(ammo_Type).ammo_Amount ;
    }

    public void Increase_Current_AMMUNITIONs_by_picking_Power_UPs(Different_AMMUNITIONS ammo_Type, int ammo_Amount)
    {
        Get_AMMO_Slot_for_Each_Individual_Weapon(ammo_Type).ammo_Amount += ammo_Amount;
    }

    public void Reduce_AMMO_amount_for_every_Firing_of_Bullets(Different_AMMUNITIONS ammo_Type)
    {
        Get_AMMO_Slot_for_Each_Individual_Weapon(ammo_Type).ammo_Amount--;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
