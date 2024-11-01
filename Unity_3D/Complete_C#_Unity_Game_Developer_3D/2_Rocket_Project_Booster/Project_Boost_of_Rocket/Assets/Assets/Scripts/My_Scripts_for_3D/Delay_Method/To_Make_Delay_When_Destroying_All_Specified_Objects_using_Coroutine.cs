using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the Example Script of Finding all Specific Objects with Tag and Destroying them one by one using a Delay method called Coroutine.
// We can give this Script to any Object that we wanted to Destroy.

public class To_Make_Delay_When_Destroying_All_Specified_Objects_using_Coroutine : MonoBehaviour
{
    GameObject[] Objects; // To Find and store the Existing Objects on the Screen

    public float waitingTime; // Delay Time Given From Unity.
    IEnumerator DestroyObjects() // It works as a Coroutine.
    {
        // yield return new WaitForSeconds(3f); // will make delay for 3sec. 

        Objects = GameObject.FindGameObjectsWithTag("Destroy_Object"); // Simply goes to the scene and Find all the Game objects
                                                                       // with tags "Destroy_Object" and store them into Array Variable "Objects".

        foreach (GameObject o in Objects) // Now, for every 3 sec, a sphere gets destroyed individually
        {
            yield return new WaitForSeconds(3f); // will make delay for 3sec. 

            Destroy(o);
        }
    }

    IEnumerator DestroyObjects(float waitingTime) // It works as a Coroutine.
    {
        // yield return new WaitForSeconds(3f); // will make delay for 3sec. 

        Objects = GameObject.FindGameObjectsWithTag("Destroy_Object"); // Simply goes to the scene and Find all the Game objects
                                                                       // with tags "Destroy_Object" and store them into Array Variable "Objects"

        foreach (GameObject o in Objects) // Now, according to the given waitingTime, a sphere gets destroyed individually
        {
            yield return new WaitForSeconds(waitingTime); // will make delay for 3sec. 

            Destroy(o);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Invoke("DestroyObjects", 3f); // A Simple Delay Method that Destroys all Objects after 3sec.
        // or
        // Let's try Coroutine, A more powerful way to delay our Execution, also we can Parallely run Multiple codes Together.

        StartCoroutine(DestroyObjects(waitingTime));
    }


    // Update is called once per frame
    void Update()
    {
        
    }

}
