using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Death_Handler : MonoBehaviour
{
    [SerializeField] Canvas Player_Dead_Canvas;

    // Start is called before the first frame update
    void Start()
    {
        Player_Dead_Canvas.enabled = false;
    }

    public void Player_Death_Handler()
    {
        Player_Dead_Canvas.enabled = true;

        Time.timeScale = 0;

        FindObjectOfType<Switch_Between_WEAPONs>().enabled = false;

        FindObjectOfType<Weapon>().enabled = false;

        Cursor.lockState = CursorLockMode.None;

        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
