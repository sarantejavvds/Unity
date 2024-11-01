using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HERO_Ship_Controls : MonoBehaviour
{
    float X_Position, Y_Position;

    [Header("Control Speed")]
    [Tooltip("Moves Hero_Ship Up/Down fastly based on User Input")]
    public float Control_Speed = 30f;

    [Header("Range for Position")]
    [Tooltip("Let's Limit the Height of X and Y positions our Player_Ship can go.")]
    public float X_Range_Position = 15f;
    
    public float Y_Range_Position = 10f;


    [Header("Rotation Settings")]
    public float Position_Pitch_Factor = -2f;

    public float Control_Pitch_Factor = -15f;
    
    public float Position_Yaw_Factor = 2f;

    public float Control_Roll_Factor = -20f;


    [Header("Array of Lasers")]
    [Tooltip("Give Laser Instances as Input which are under the Hero_ship")]
    public GameObject[] Lasers;

    


    // Start is called before the first frame update
    void Start()
    {

    }

    void Process_Movement()
    {
        X_Position = Input.GetAxis("Horizontal");

        Y_Position = Input.GetAxis("Vertical");

        float X_Offset = X_Position * Time.deltaTime * Control_Speed;

        float new_X_Position = transform.localPosition.x + X_Offset;

        float Y_Offset = Y_Position * Time.deltaTime * Control_Speed;

        float new_Y_Position = transform.localPosition.y + Y_Offset;

        float Clamped_X_Position = Mathf.Clamp(new_X_Position, -X_Range_Position, X_Range_Position);

        float Clamped_Y_Position = Mathf.Clamp(new_Y_Position, -Y_Range_Position, Y_Range_Position);

        transform.localPosition = new Vector3(Clamped_X_Position, Clamped_Y_Position, transform.localPosition.z);
    }

    void Process_Rotation()
    {
        float Position_Impacting_Pitch = transform.localPosition.y * Position_Pitch_Factor;

        float Control_Input_Impacting_Pitch = Y_Position * Control_Pitch_Factor;

        float pitch = Position_Impacting_Pitch + Control_Input_Impacting_Pitch;


        float Position_Impacting_Yaw = transform.localPosition.x * Position_Yaw_Factor;

        float yaw = Position_Impacting_Yaw;


        float Control_Input_Impacting_Roll = X_Position * Control_Roll_Factor;

        float roll = Control_Input_Impacting_Roll;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

    }

    void SetActive_Lasers(bool isActive)
    {
        foreach (GameObject each_Laser in Lasers)
        {
            var emissionModule_1 = each_Laser.GetComponent<ParticleSystem>().emission;

            emissionModule_1.enabled = isActive;
        }
    }

    void Process_Firing()
    {
        //if(Input.GetButton("Fire1"))
        if(Input.GetKey(KeyCode.Space))
        {
            SetActive_Lasers(true);
        }
        else
        {
            SetActive_Lasers(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Process_Movement();

        Process_Rotation();

        Process_Firing();
    }

}
