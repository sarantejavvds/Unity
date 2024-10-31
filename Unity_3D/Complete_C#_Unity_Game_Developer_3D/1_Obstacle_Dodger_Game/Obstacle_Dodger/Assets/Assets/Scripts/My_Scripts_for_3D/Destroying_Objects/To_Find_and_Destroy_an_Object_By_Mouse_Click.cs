using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class To_Find_and_Destroy_an_Object_By_Mouse_Click : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown() // When mouse is on a click
    {
        if (this.gameObject.tag == "Destroy_Object") // Checks if the object that the mouse clicked is tagged as "Destroy_Object" or not.
                                                     // can also change it to any other Tag if we want to destroy a particular Tagged object.
        {
            Destroy(gameObject); // Destroys object when mouse is clicked.                                    
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
