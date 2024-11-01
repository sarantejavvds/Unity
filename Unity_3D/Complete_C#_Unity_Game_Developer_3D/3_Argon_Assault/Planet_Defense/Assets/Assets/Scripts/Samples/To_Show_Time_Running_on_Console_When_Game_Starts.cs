using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class To_Show_Time_Running_on_Console_When_Game_Starts : MonoBehaviour
{
    public float Time_To_Wait;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Timer : " + Time.time);

        if(Time.time > Time_To_Wait)
        {
            Debug.Log(Time_To_Wait + " seconds has been Elapsed or Already Completed");
        }

    }

}
