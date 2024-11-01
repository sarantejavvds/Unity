using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used to Move the Object using Keyboard Inputs (by making our game frame rate independent).
// Give this script to the object that we want to move.

public class Move_a_NonRigidbody_Object_Dynamically_with_Help_of_TimeDeltaTime : MonoBehaviour
{
    public float moveSpeed; // To give Input for moveSpeed from Unity.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Move_Object()
    {
        float X_value = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed; // Getting access to X-axis,
                                                                                  // makng it Frame Rate Independent with help of Time.DeltaTime,
                                                                                  // and giving correct Movement Speed.

        float Z_value = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed; // Getting access to Z-axis,
                                                                                // makng it Frame Rate Independent with help of Time.DeltaTime,
                                                                                // and giving correct Movement Speed.

        transform.Translate(X_value, 0, Z_value); // Getting access to Transform class in Unity, using Translate method for Movement.

    }

    // Update is called once per frame
    void Update()
    {
        Move_Object();
    }

}
