using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the Example to Make the Player Jump to Upward Direction.
// Give this Script to Player.

public class To_Make_Player_Object_Jump_Upward : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>(); // gets access to the Rigidbody Component.
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))  // Checking if Space was pressed.
        {
            rb.AddForce(Vector3.up * 500); // Adding some force of 500 amount towards Upward Direction.
        }
    }
}
