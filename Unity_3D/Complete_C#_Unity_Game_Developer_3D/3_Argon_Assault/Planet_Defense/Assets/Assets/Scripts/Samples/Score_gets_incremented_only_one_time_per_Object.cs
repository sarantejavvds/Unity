using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_gets_incremented_only_one_time_per_Object : MonoBehaviour
{
    int hits = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter(Collision other_Object)
    {
        
        if(other_Object.gameObject.tag != "Hit")
        {
            hits++;

            Debug.Log("You've Bumped into this number of Objects  : " + hits);

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

}
