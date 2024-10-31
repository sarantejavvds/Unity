using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_the_Colour_of_Object_for_which_this_Script_was_Given_When_Collision_Occured : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("Player Bumped Into a Wall");

       // Console.WriteLine("Hi");

        GetComponent<MeshRenderer>().material.color = Color.gray;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
