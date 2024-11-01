using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This is the Example Script of We can choose to Reload our Game Scene or We can Proceed to Next Game Scene, if the selected key was pressed.
// Give this Script to Player Object or any Object that gonna finish it's task at the end of the Scene.

public class To_Make_Game_Scene_Reload_or_NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N)) // Checking if "N" button is pressed from the Keyboard.
        {
            SceneManager.LoadScene("Game_Level_1"); // Loads the Scene "Game_Level_1" (or can give other Game Scene Name too)
                                                       // if "N" is pressed.
                                                          // We can choose to stay in the Same Level or Proceed to Next Level. 
        }
    }
}
