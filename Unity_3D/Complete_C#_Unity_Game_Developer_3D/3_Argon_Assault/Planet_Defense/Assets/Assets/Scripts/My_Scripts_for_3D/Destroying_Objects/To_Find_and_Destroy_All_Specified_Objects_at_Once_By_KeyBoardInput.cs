using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This is the Example Script of Finding all Specific Objects with Tag and Destroying them by Using KeyBoard Input.
// We can give this Script to any Object that we wanted to Destroy.

public class To_Find_and_Destroy_All_Specified_Objects_at_Once_By_KeyBoardInput : MonoBehaviour
{
    GameObject[] Objects; // An array to store all Objects on the scene specified with a Tag.

    // Start is called before the first frame update
    void Start()
    {
        Objects = GameObject.FindGameObjectsWithTag("Destroy_Object"); // Simply goes to the scene and Find all the Game objects
                                                                       // with tags "Destroy_Object" and store them into Array Variable "Objects".
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0)) // When a "0" Key was pressed, all Objects tagged with "Destroy_Object" will be destroyed 
        {
            foreach (GameObject o in Objects)
            {
                Destroy(o.gameObject);
            }
        }
    }

}
