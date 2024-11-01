using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the Example of How to change Colour of the Player when other object touches it.
// Give this to Player or any other object that you want to change the colour.

public class To_Make_Player_Colour_Change_When_Touch_Other_Object : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision) // Detects if Collision happen between objects
    {
        GetComponent<Renderer>().material.color = Color.red; // The object "ball" color changes to "red" after it spawns and Collide with plane ( or any other object).
                                                                // We can Put any other Colour here, instead of "red".
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
