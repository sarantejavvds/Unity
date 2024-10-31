using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Loader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Reload_Current_Scene()
    {
        Debug.Log("Reload Scene?");

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);

        Time.timeScale = 1;
    }

    public void Quit_Game()
    {
        Debug.Log("Quit?");

        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
