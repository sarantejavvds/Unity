using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator_of_Objects : MonoBehaviour
{
    Vector3 StartingPosition;  // By Default it will Take Current Position of Object from Unity. 

    public Vector3 Movement_Vector;  // The Distance that the Object(Obstacle) wants to Move.

    [SerializeField] [Range(0,1)] float Movement_Factor; // Range was set between 0 and 1. 
                                                         // with help of Serialize Field.

    public float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartingPosition = transform.position; // Current Position of the Object

        Debug.Log("Starting Position : " + StartingPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon)
        {
            return;
        }

        float cycles = Time.time / period;  // Continuously increases overtime

        const float Tau = Mathf.PI * 2;  // 6.28 radians  or  a Full Circle  or  a Complete Lap.

        float Raw_Sine_Wave = Mathf.Sin(cycles * Tau); // Amplitude of  -1 to +1

        Movement_Factor = (Raw_Sine_Wave + 1f) / 2f;

        Vector3 offset = Movement_Vector * Movement_Factor;

        transform.position = StartingPosition + offset;
    }

}
