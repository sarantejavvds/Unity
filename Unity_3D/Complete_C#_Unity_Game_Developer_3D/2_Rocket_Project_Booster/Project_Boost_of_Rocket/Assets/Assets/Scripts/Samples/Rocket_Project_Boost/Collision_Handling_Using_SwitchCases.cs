using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision_Handling_Using_SwitchCases : MonoBehaviour
{
    AudioSource Audio_Source;

    public AudioClip Success_Audio;

    public AudioClip Exploded_Audio;

    public float delay_to_LoadLevel;

    public ParticleSystem Succeeded_Particles;

    public ParticleSystem Exploded_Particles;

    bool isTransitioning = false;

    bool CollisionDisabler = false;  // A cheat Key.

    // Start is called before the first frame update
    void Start()
    {
        Audio_Source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
     //   Respond_To_Cheats();
    }

    void Reload_the_Level()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);  // or
                                                    // SceneManager.LoadScene("Space_Rocket_Level_1"); // To Load this particular Game Scene.
    }

    void Start_When_Crash_Sequence()
    {
        isTransitioning = true;

        Audio_Source.Stop();

        Audio_Source.PlayOneShot(Exploded_Audio); // Plays Explosion Audio when Rocket Crashed.

        Exploded_Particles.Play();   // Play Particles Effect when Rocket Exploded.

        GetComponent<Rocket_Movement>().enabled = false;  // Makes "Rocket_Movement" script Disabled, So Rocket Won't be abled to move anymore.

        Invoke("Reload_the_Level", delay_to_LoadLevel); // Reloads the Level after the Delay given from Unity.
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
        isTransitioning = true;

        Audio_Source.Stop();

        Audio_Source.PlayOneShot(Success_Audio);  // Plays Success Audio when Finished the Level.

        Succeeded_Particles.Play();  // Play Success Particles when Rocket Reaches Finish Line.

        GetComponent<Rocket_Movement>().enabled = false;  // Makes "Rocket_Movement" script Disabled, So Rocket Won't be abled to move anymore.

        Invoke("Load_Next_Level", delay_to_LoadLevel); // Reloads the Next Level after the Delay given from Unity.
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if(isTransitioning)
        {
            return;
        }
         
        //if (isTransitioning  ||  CollisionDisabler)
        //{
        //    return;
        //}

        switch(other.gameObject.tag)
        {
            case "FRIENDLY" : Debug.Log("This Object is Friendly ");

                              break;

            case "FINISH"   : Debug.Log("Congratulations !!, You Reached Finish Line Successfully !! ");
                              // Load_Next_Level();
                              Start_When_Reached_SuccessLine_Sequence();

                              break;

            case "FUEL"     : Debug.Log("You Picked up Fuel ");

                              break;

            default         : Debug.Log("Sorry, You Blew into pieces ");
                              // Reload_the_Level();
                              Start_When_Crash_Sequence();

                              break;
        }
    }

    void Respond_To_Cheats()
    {
        if(Input.GetKey(KeyCode.N))
        {
            Load_Next_Level();
        }
        else if(Input.GetKey(KeyCode.C))
        {
            CollisionDisabler = !CollisionDisabler;
        }
    }

}
