using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public bool isPlaceable;

    public TOWER Tower_prefab;

    public bool IsPlaceable {  get { return isPlaceable; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(isPlaceable)
        {
            Debug.Log("Placed here : " + transform.name);

            bool isPlaced = Tower_prefab.Create_Tower_Here(Tower_prefab, transform.position);            

            isPlaceable = !isPlaced;
        }
    }

}
