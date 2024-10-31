using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Between_WEAPONs : MonoBehaviour
{
    public int current_Holding_Weapon = 0;



    void Set_Weapon_Visibility_Active()
    {
        int Weapon_Index = 0;

        foreach(Transform weapon in transform)
        {
            if(Weapon_Index == current_Holding_Weapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            Weapon_Index++;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        Set_Weapon_Visibility_Active();
    }

    void Player_Input_Through_Keyboard()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            current_Holding_Weapon = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            current_Holding_Weapon = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            current_Holding_Weapon = 2;
        }
    }
    
    void Player_Input_Through_Mouse_Scrolls()
    { 
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        { 
            if(current_Holding_Weapon >= transform.childCount - 1)
            {
                current_Holding_Weapon = 0;
            }
            else
            {
                current_Holding_Weapon++;
            }
        }
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        { 
            if(current_Holding_Weapon <= 0)
            {
                current_Holding_Weapon = transform.childCount - 1;
            }
            else
            {
                current_Holding_Weapon--;
            }
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        int previous_Weapon = current_Holding_Weapon;

        Player_Input_Through_Keyboard();

        Player_Input_Through_Mouse_Scrolls();

        if(previous_Weapon != current_Holding_Weapon)
        {
            Set_Weapon_Visibility_Active();
        }

    }

}
