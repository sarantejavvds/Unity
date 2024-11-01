using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Self_Destruct : MonoBehaviour
{
    public float Time_till_Destroy = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, Time_till_Destroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
