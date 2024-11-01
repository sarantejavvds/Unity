using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the Example Script to make the Player Find an Enemy tagged Object and Destroys that Enemy Object.
// Give this Script to the Player Object.

public class To_Find_and_Destroy_an_ENEMY : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision) // Method that detects the Collision between objects.
    {
        if (collision.gameObject.tag == "ENEMY") // Checking if "ENEMY_1" tagged object is Detected or touched.
        {
            //Destroy(gameObject);  // Destroys the our Player, if "ENEMY" tagged object touches it.

            Destroy(collision.gameObject); // "ENEMY_1" tagged object gets Destroyed if it gets Contacted with Cube.
            // If both Destroy Methods are working at same time, then both objects will gets Destroyed.

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
