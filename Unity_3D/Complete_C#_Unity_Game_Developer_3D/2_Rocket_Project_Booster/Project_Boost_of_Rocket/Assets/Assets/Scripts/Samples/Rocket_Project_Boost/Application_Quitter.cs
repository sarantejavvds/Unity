using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Application_Quitter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Escape))
      {
            Debug.Log("We Pushed Escape Button !");

            Application.Quit();
      }

    }

}
