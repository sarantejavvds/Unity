using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reach_Target_for_Next_Level : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Load_Next_Level()
    {
        Treasure_Bank treasure = FindObjectOfType<Treasure_Bank>();

        int current_Scene_Index = SceneManager.GetActiveScene().buildIndex;

        if (current_Scene_Index == 0) // at Level_1
        {
            if (treasure.Current_Balance >= 300  && treasure.Current_Balance <= 350) // Target = 300
            {
                SceneManager.LoadScene(current_Scene_Index + 1); // Loads Level_2
            }
        }
        else if(current_Scene_Index == 1) // at Level_2
        {
            if (treasure.Current_Balance >= 350 && treasure.Current_Balance <= 400) // Target = 350
            {
                SceneManager.LoadScene(current_Scene_Index + 1); // Loads Level_3
            }
        }
        else if (current_Scene_Index == 2) // at Level_3
        {
            if (treasure.Current_Balance >= 500 && treasure.Current_Balance <= 550) // Target = 500
            {
                SceneManager.LoadScene(current_Scene_Index + 1); // Loads Last Scene
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        Load_Next_Level();
    }
}
