using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class To_Spin_or_Rotate_an_Object : MonoBehaviour
{
    public float X_Angle;
    public float Y_Angle;
    public float Z_Angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(X_Angle, Y_Angle, Z_Angle);
    }
}
