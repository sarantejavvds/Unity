using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reached_Finish_Safe : MonoBehaviour
{
    public float delay_to_LoadLevel = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Load_Next_Level()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int NextSceneIndex = currentSceneIndex + 1;

        /*
         // If we wanted to Load Initial Level after Reaching Max Level, use this code.

         if(NextSceneIndex == SceneManager.GetActiveScene().buildIndex)
         {
             NextSceneIndex = 0;  
         }

          SceneManager.LoadScene(NextSceneIndex);  // Loads Next Scene.
         
         */

        if (NextSceneIndex < SceneManager.sceneCountInBuildSettings)   // Checks , if we Reached Max Level or Not.
        {
            SceneManager.LoadScene(NextSceneIndex);  // Loads Next Scene.
        }
        else
        {
            Debug.Log("Congratulations !!, You've Reached the End Level !!! ");
        }

    }

    void Start_When_Reached_SuccessLine_Sequence()
    {
        //  isTransitioning = true;

        //  Audio_Source.Stop();

        //  Audio_Source.PlayOneShot(Success_Audio);  // Plays Success Audio when Finished the Level.

        //  Succeeded_Particles.Play();  // Play Success Particles when Rocket Reaches Finish Line.

        // GetComponent<Rocket_Movement>().enabled = false;  // Makes "Rocket_Movement" script Disabled, So Rocket Won't be abled to move anymore.

        Load_Next_Level();
        //Invoke("Load_Next_Level", delay_to_LoadLevel); // Reloads the Next Level after the Delay given from Unity.
    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    Debug.Log("Touched");
    //    switch(other.gameObject.tag)
    //    {
    //        case "SAFE" : Debug.Log("Congratulations !!, You Reached Finish Line Successfully !! ");
    //                      // Load_Next_Level();
    //                      Start_When_Reached_SuccessLine_Sequence();
    //                      break;

    //        default    : Debug.Log("Nothing");
    //                     break;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Touched" + other.name);
        switch (other.gameObject.tag)
        {
            case "Player":
                         Debug.Log("Congratulations !!, You Reached Finish Line Successfully !! ");
                
                         Start_When_Reached_SuccessLine_Sequence();

                         break;

        }
    }

}
