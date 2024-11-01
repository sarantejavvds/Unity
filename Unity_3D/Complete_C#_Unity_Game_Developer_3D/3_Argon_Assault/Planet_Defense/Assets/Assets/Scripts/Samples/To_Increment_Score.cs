using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class To_Increment_Score : MonoBehaviour
{
    int hits = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        hits++;

        Debug.Log("You've Bumped into another Object this many Times : " + hits);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
