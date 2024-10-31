using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Make_Aerial_Object_Fall_after_Certain_Amount_of_Time : MonoBehaviour
{
    public float Time_To_Wait;

    MeshRenderer meshRenderer;

    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        rigidBody = GetComponent<Rigidbody>();

        meshRenderer.enabled = false;

        rigidBody.useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > Time_To_Wait)
        {

            meshRenderer.enabled = true;

            rigidBody.useGravity = true;

        }

    }

}
