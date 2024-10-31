using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display_Blood_of_Player_when_Damage_Taken : MonoBehaviour
{
    public Canvas Blood_Splatter_Impact_Canvas;

    public float Impact_time_for_Every_Attack = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        Blood_Splatter_Impact_Canvas.enabled = false;
    }

    IEnumerator Show_Blood_Splatter()
    {
        Blood_Splatter_Impact_Canvas.enabled = true;

        yield return new WaitForSeconds(Impact_time_for_Every_Attack);

        Blood_Splatter_Impact_Canvas.enabled = false;
    }

    public void  Show_Damage_Impact()
    {
        StartCoroutine( Show_Blood_Splatter() );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
