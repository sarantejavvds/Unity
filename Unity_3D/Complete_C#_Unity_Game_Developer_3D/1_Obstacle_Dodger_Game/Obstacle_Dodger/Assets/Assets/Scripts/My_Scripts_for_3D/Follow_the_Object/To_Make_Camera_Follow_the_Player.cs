using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This is the Example of How to Make Camera Follow the Player wherever He/She went.
// Give this script to Main Camera.

public class To_Make_Camera_Follow_the_Player : MonoBehaviour
{
    public Transform target; // Target is the object which we want to follow
                                // Whatever the target we Gave in Unity, the Camera will Follow it.

    Vector3 offset; // To find Distance between Player's Position and Camera's Position.

    // Start is called before the first frame update
    void Start()
    {
        offset = target.position - transform.position; //  Calculates the Difference to keep the Position and difference always Same.
    }

    // Update is called once per frame
    void Update()
    {
      //  transform.LookAt(target); // Camera will always look at the target and follow it.
                                       // We can Directly use this above method instead of using "offset" variable and Difference Calculation.
    }

    private void FixedUpdate()
    {
        transform.position = target.position - offset; // Makes Camera 
    }
}
