using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class New_Player_Controls_Input_System : MonoBehaviour
{
    public InputAction movement;

    private void OnEnable()
    {
        movement.Enable(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float X_axis = movement.ReadValue<Vector2>().x;
        Debug.Log("X axis : " + X_axis);

        float Y_axis = movement.ReadValue<Vector2>().y;
        Debug.Log("Y axis : " + Y_axis);
    }

    private void OnDisable()
    {
        movement.Disable();
    }

}
