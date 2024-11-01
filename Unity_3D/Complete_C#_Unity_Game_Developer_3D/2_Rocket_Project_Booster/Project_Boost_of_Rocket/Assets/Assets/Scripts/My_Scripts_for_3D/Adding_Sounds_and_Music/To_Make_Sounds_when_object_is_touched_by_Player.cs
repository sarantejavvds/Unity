using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the Example of How to make other Object makes Sound when Player touched it.
// Give this script to Player.

public class To_Make_Sounds_when_object_is_touched_by_Player : MonoBehaviour
{
    public AudioClip coinSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().PlayOneShot(coinSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
