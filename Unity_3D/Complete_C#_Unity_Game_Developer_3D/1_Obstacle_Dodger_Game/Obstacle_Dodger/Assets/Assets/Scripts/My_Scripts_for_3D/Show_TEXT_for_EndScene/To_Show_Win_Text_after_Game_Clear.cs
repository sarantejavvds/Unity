using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the Example of When all the other Objects are Touched through the Player and Winner Text will be shown.
// Give this script to Player.

public class To_Show_Win_Text_after_Game_Clear : MonoBehaviour
{
    int coinsCollected;

    public GameObject winText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GoldCoin")
        {
            coinsCollected++;
        }

        if(coinsCollected >= 10)
        {
            winText.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
