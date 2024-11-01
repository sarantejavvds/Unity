using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is for Moving an Object(Non-Rigidbody Preferrable) to the Direction input given from Unity's Inspector
// Can give this script to an object.

// Not Preferred to use at the moment.

public class Move_An_Object_Towards_and_Away_From_the_Camera_Using_Serialize_Fields : MonoBehaviour
{
    [SerializeField] float Neg_X; // To command unity to move the object in Negative X - axis
    [SerializeField] float Pos_X; // To command unity to move the object in Positive X - axis

    [SerializeField] float Neg_Y; // To command unity to move the object in Negative Y - axis
    [SerializeField] float Pos_Y; // To command unity to move the object in Positive Y - axis

    [SerializeField] float Neg_Z; // To command unity to move the object in Negative Z - axis
    [SerializeField] float Pos_Z; // To command unity to move the object in Positive Z - axis

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Negative_Movement()
    {
        transform.Translate(Neg_X, Neg_Y, Neg_Z);
    }
    
    void Positive_Movement()
    {
        transform.Translate(Pos_X, Pos_Y, Pos_Z);
    }

    // Update is called once per frame
    void Update()
    {

        Invoke("Negative_Movement", 2f);

        Invoke("Positive_Movement", 2f);
        
    }
}
