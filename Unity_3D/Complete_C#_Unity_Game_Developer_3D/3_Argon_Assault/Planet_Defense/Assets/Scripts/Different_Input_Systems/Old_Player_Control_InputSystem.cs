using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Old_Player_Control_InputSystem : MonoBehaviour
{
    float X_Position, Y_Position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        X_Position = Input.GetAxis("Horizontal");

        Y_Position = Input.GetAxis("Vertical");

        Debug.Log("X axis : " + X_Position);

        Debug.Log("Y axis : " + Y_Position);
    }

}
