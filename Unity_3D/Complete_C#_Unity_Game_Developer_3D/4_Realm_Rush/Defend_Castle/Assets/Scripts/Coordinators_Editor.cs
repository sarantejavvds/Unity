using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class Coordinators_Editor : MonoBehaviour
{
    TextMeshPro Label;

    Vector2Int coordinates = new Vector2Int();

    WayPoint wayPoint;

    public Color Default_Colour = Color.white;

    public Color Blocked_Colour = Color.gray;

    void Display_Coordinates()
    {
    //    coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x); 

    //    coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / 10);

        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / 10);

        Label.text = coordinates.x + "," + coordinates.y;
    }

    void Update_Object_Name()
    {
        transform.parent.name = coordinates.ToString();
    }

    // Start is called before the first frame update
    void Awake()
    {
        Label = GetComponent<TextMeshPro>();

        Label.enabled = false;

        wayPoint = GetComponentInParent<WayPoint>();
    }

    void Colour_Coordinates()
    {
        if(wayPoint.IsPlaceable)
        {
            Label.color = Default_Colour;
        }
        else
        {
            Label.color = Blocked_Colour;
        }
    }

    void Toggle_Labels()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            Label.enabled = !Label.IsActive();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying)
        {
            Display_Coordinates();

            Update_Object_Name();

            Label.enabled = true;
        }

        Colour_Coordinates();

        Toggle_Labels();
    }

}
