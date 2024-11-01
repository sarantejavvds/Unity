using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; // To access Scene related Methods.

// This is the Example of Restarting the Game whenever the Player Falls away from the Ground into Oblivion.
// Give this script to Player.
public class To_Make_Game_Restarts_Whenever_The_Player_Falls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Restart() // This method will Restarts the Game Scene.
    {
        if(transform.position.y <= -5f)  // Checks if the Player Position is valid upto Y-axis's "-5f".
        {
            SceneManager.LoadScene(2);  // Loads the Scene to it's Start Point.
        }

    }

    // Update is called once per frame
    void Update()
    {
        Restart();  
    }
}
