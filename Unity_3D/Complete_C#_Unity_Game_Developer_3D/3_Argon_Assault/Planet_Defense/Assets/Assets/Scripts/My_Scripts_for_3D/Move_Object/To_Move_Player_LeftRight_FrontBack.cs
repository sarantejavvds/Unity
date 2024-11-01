using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the Example to Move our Player in all Left, Right, Front, Back Directions.
// Give this script to Player.
public class To_Move_Player_LeftRight_FrontBack : MonoBehaviour
{
    public float moveSpeed; // For the Movement speed of the Player (input is given from Unity).

    float X_Input; // To move Player in Left and Right Directions.

    float Z_Input; // To move Player in Front and Back Directions.

    Rigidbody rb; // We have to add Rigidbody Component to the Player to use this.

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // gets access to Rigidbody of the Player.
                                           // by using "rb" variable.
    }

    // Update is called once per frame
    void Update()
    {
        X_Input = Input.GetAxis("Horizontal"); // gives access to move Player in Left and Right Directions.

        Z_Input = Input.GetAxis("Vertical"); // gives access to move Player in Front and Back Directions.
    }

    private void FixedUpdate()
    {
        // rb.AddForce(X_Input * moveSpeed, 0 , Z_Input * moveSpeed); 

        rb.velocity = new Vector3(X_Input * moveSpeed, rb.velocity.y, Z_Input * moveSpeed); // Adds momentum to the Player to Move Left, Right, Front, Back.
                                                                                            // Y axis Should be fixed.

    }

}
