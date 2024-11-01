using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To Move Our Object in all 4 Directions (Not in the Air) using Keyboard Inputs.
// Can give this script to Object we want to move.

public class Move_a_NonRigidbody_Object_Dynamically_using_Translate_Method : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float X_value = Input.GetAxis("Horizontal");

        float Z_value = Input.GetAxis("Vertical");

        transform.Translate(X_value, 0, Z_value);
    }

}
