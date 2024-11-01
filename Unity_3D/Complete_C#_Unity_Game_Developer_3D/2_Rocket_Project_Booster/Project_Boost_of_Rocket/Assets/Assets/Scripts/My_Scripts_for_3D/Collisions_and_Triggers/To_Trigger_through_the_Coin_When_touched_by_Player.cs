using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the Example of When the other Objects are Triggered through the Player.
// Give this script to Player.

public class To_Trigger_through_the_Coin_When_touched_by_Player : MonoBehaviour
{
    int coinsCollected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "GoldCoin")
        {
            coinsCollected++;

            other.gameObject.SetActive(false); // To Deactivate the other Objects.
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
