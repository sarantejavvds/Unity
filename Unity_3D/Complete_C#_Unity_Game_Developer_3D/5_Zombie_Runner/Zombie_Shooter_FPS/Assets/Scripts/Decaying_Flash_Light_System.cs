using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decaying_Flash_Light_System : MonoBehaviour
{
    public float Light_Intensity_Decay = 0.1f;

    public float Angle_Decay = 1f;

    public float Minimum_Angle = 40f;
    
    Light decay_Light;

    // Start is called before the first frame update
    void Start()
    {
        decay_Light = GetComponent<Light>();
    }

    void Decreasing_Light_Angle_by_time()
    {
        if(decay_Light.spotAngle <= Minimum_Angle)
        {
            return;
        }
        else
        {
            decay_Light.spotAngle -= (Angle_Decay * Time.deltaTime);
        }
    }
    
    public void Restore_Light_Angle_by_Battery_Pick_Up(float Restore_Light_Angle)
    {
        decay_Light.spotAngle = Restore_Light_Angle;
    }

    void Decreasing_Light_Intensity_by_time()
    {
        decay_Light.intensity -= (Light_Intensity_Decay * Time.deltaTime);
    }

    public void Restore_Light_Intensity_by_Battery_Pick_Up(float Intnsity_Amount)
    {
        decay_Light.intensity += Intnsity_Amount;
    }

    // Update is called once per frame
    void Update()
    {
        Decreasing_Light_Angle_by_time();

        Decreasing_Light_Intensity_by_time();

    }
}
