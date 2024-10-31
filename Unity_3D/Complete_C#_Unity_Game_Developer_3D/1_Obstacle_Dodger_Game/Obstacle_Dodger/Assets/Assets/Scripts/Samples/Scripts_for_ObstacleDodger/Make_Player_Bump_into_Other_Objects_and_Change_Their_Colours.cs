using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Give this Script to All Objects (except Player).

public class Make_Player_Bump_into_Other_Objects_and_Change_Their_Colours : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other_Object) // Checks if an Object Collides the "Object with this Script" 
    {
        if(other_Object.gameObject.tag == "PLAYER") // Checks that If the other Game Object is "PLAYER" tagged or not.
        {
            GetComponent<MeshRenderer>().material.color = Color.black; 

            gameObject.tag = "Hit"; // "The Object that holds this Script" gets it's tag changed to "Hit", when collided by Player.
        }
    }

}
