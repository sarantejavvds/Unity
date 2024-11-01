using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class To_Find_and_Change_Colour_of_an_Object_By_Mouse_Click : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown() // When mouse is on a click
    {
        if (this.gameObject.tag == "Change_Colour") // Checks if the object that the mouse clicked is tagged as "Change_Colour" or not.
                                                    // can also change it to any other Tag if we want to change Colour of a particular Tagged object.
        {

            GetComponent<Renderer>().material.color = Color.red;  // If clicked on the Objects tagged as "Change_Colour", their colors gets changed to red
                                                                  // but not for any other Objects on the Scene, because the tag in condition is "Change_Colour".
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
