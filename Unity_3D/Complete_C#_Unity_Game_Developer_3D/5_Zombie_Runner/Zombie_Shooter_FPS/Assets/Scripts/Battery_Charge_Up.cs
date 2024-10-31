using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery_Charge_Up : MonoBehaviour
{
    public float Restore_Light_Angle = 90f;

    public float Increment_Intensity = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player picked up battery");

            other.GetComponentInChildren<Decaying_Flash_Light_System>().Restore_Light_Angle_by_Battery_Pick_Up(Restore_Light_Angle);

            other.GetComponentInChildren<Decaying_Flash_Light_System>().Restore_Light_Intensity_by_Battery_Pick_Up(Increment_Intensity);

            Destroy(gameObject);
        }
    }

}
