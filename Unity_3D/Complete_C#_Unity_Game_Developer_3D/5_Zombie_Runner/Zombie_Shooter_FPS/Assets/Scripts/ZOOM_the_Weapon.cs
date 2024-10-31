using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.Characters.FirstPerson;
using Cinemachine;



public class ZOOM_the_Weapon : MonoBehaviour
{
    [SerializeField] Camera FPS_Camera;

    [SerializeField] CinemachineVirtualCamera vcam;

    bool Zoomed_In_Toggle = false;

    public float Zoom_In_by_FEILD_OF_VIEW = 20f;

    public float Zoom_Out_by_FEILD_OF_VIEW = 60f;



    // RigidbodyFirstPersonController fps_Controller;



    // Start is called before the first frame update
    void Start()
    {
        // fps_Controller = GetComponent<RigidbodyFirstPersonController>();
    }

    void ZOOM_In()
    {
        Zoomed_In_Toggle = true;

        vcam.m_Lens.FieldOfView = Zoom_In_by_FEILD_OF_VIEW;
    }

    void ZOOM_Out()
    {
        Zoomed_In_Toggle = false;

        vcam.m_Lens.FieldOfView = Zoom_Out_by_FEILD_OF_VIEW;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))  // click on Right Mouse Button to Zoom_In
        //if (Input.GetKeyDown(KeyCode.Z))
        {
           // Debug.Log("Clicked z button ");
            if (Zoomed_In_Toggle == false)
            {
                ZOOM_In();
            }
            else
            {
                ZOOM_Out();
            }
        }
    }

    void OnDisable()
    {
        ZOOM_Out();
    }

}
