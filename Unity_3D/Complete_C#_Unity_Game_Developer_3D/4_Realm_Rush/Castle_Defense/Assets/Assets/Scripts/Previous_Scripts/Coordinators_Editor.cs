using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEditor;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class Coordinators_Editor : MonoBehaviour
{
    TextMeshPro Label;

    Vector2Int coordinates = new Vector2Int();

    // WayPoint wayPoint;

    Grid_Manager grid_Manager;

    public Color Default_Colour = Color.white;

    public Color Blocked_Colour = Color.gray;
    
    public Color Explored_Colour = Color.yellow;

    public Color Path_Colour = new Color(1f, 0.5f, 0f);

    void Display_Coordinates()
    {
        // coordinates.x = Mathf.RoundToInt(transform.parent.position.x / EditorSnapSettings.move.x); 

        //  coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        if(grid_Manager == null)
        { 
            return;
        }

        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / grid_Manager.Unity_World_GridSize);

        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / grid_Manager.Unity_World_GridSize);

        Label.text = coordinates.x + "," + coordinates.y;
    }

    void Update_Object_Name()
    {
        transform.parent.name = coordinates.ToString();
    }

    // Start is called before the first frame update
    void Awake()
    {
        grid_Manager = FindObjectOfType<Grid_Manager>();

        Label = GetComponent<TextMeshPro>();

        Label.enabled = false;

       //  wayPoint = GetComponentInParent<WayPoint>();
    }

    void Colour_Coordinates()
    {
        if(grid_Manager == null)
        {
            return;
        }

        Node node = grid_Manager.GetNode(coordinates);

        if(node == null)
        {
            return;
        }

        if(!node.isWalkable)
        {
            Label.color = Blocked_Colour;
        }
        else if(node.isPath)
        {
            Label.color = Path_Colour;
        }
        else if(node.isExplored)
        {
            Label.color = Explored_Colour;
        }
        else
        {
            Label.color = Default_Colour;
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
