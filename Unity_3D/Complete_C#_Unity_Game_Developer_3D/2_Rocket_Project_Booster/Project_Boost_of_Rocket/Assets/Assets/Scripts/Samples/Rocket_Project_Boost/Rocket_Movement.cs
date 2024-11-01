using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_Movement : MonoBehaviour
{
    Rigidbody rb;

    AudioSource Audio_Source;

    public AudioClip Rocket_Sound;

    public ParticleSystem MainEngine_Fire;

    public ParticleSystem LeftThrustParticles;

    public ParticleSystem RightThrustParticles;

    public float move_by_Thrust;

    public float Thrust_to_Rotate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Audio_Source = GetComponent<AudioSource>();
    }

    void Start_Thrusting()
    {
        Debug.Log("Pressed Space for Thrusting");

        rb.AddRelativeForce(Vector3.up * move_by_Thrust * Time.deltaTime); // Adds a Force to Rigidbody relative to it's Coordinate System
                                                                           // using "Time.deltaTime" to make our Object "Frame Rate Independent".

        if (!Audio_Source.isPlaying)
        {
            // Audio_Source.Play();
            Audio_Source.PlayOneShot(Rocket_Sound);
        }

        if (!MainEngine_Fire.isPlaying)
        {
            MainEngine_Fire.Play();
        }
    }

    void Stop_Thrusting()
    {
        Audio_Source.Stop();

        MainEngine_Fire.Stop();
    }

    void Process_Thrust()
    { 
       if(Input.GetKey(KeyCode.Space))
       {            
            Start_Thrusting();
       }
       else
       {            
            Stop_Thrusting();
       }

    }
    
    void Apply_Rotation(float Rotation_at_This_Frame)
    {
        rb.freezeRotation = true;  // Freezing Rotation so we can Manually Rotate the Object.

        transform.Rotate(Vector3.forward * Rotation_at_This_Frame * Time.deltaTime);

        rb.freezeRotation = false; // Unfreezing the Rotation, so Physics system can takeover.
    }

    void Rotate_Left()
    {
        Apply_Rotation(Thrust_to_Rotate);

        if (!RightThrustParticles.isPlaying)
        {
            RightThrustParticles.Play();
        }

    }

    void Rotate_Right()
    {
        Apply_Rotation(-Thrust_to_Rotate);

        if (!LeftThrustParticles.isPlaying)
        {
            LeftThrustParticles.Play();
        }

    }

    void Stop_Rotating()
    {
        LeftThrustParticles.Stop();

        RightThrustParticles.Stop();
    }

    void Process_Rotation()
    { 
       if(Input.GetKey(KeyCode.LeftArrow))
       {
            Debug.Log("Pressed LeftArrow for Thrusting Left");
            
            Rotate_Left();
       }        
       else if (Input.GetKey(KeyCode.RightArrow))
       {
            Debug.Log("Pressed RightArrow for Thrusting Right");
            
            Rotate_Right();
        }
       else
       {
            Stop_Rotating();            
       }
            
    }

    // Update is called once per frame
    void Update()
    {
        Process_Thrust();

        Process_Rotation();
    }

}
