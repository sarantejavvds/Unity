using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class To_Find_and_Destroy_All_Similar_Objects_at_Once : MonoBehaviour
{
    GameObject[] Objects; // An array to store all Objects on the scene specified with a Tag.

    void DestroyAllObjects() // A method call to Destroy all Objects in the Scene.
    {
        Objects = GameObject.FindGameObjectsWithTag("Destroy_Object"); // To Find all Game Objects wit the Tag "Destroy_Object"

        foreach (GameObject o in Objects)
        {
            Destroy(o);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       DestroyAllObjects();  // Calling the Method "DestroyAllObjects" in "Start()" method.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
