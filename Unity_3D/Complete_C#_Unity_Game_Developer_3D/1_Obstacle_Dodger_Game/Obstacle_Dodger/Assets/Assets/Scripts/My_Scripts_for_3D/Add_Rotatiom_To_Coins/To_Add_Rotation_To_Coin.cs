using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the Example of How to rotate the Coins at their own Positions.
// Give this script to Coin Objects.


public class To_Add_Rotation_To_Coin : MonoBehaviour
{
    public float rotateSpeed; // Rotation Speed given from Unity.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, -rotateSpeed, 0); // Adds Rotation at Right Direction.
    }

}
