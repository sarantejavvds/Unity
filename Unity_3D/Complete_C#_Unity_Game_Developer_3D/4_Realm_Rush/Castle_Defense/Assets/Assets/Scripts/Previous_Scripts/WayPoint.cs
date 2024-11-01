using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public bool isPlaceable; 
    public bool IsPlaceable { get { return isPlaceable; } }

    public TOWER Tower_prefab;

    Grid_Manager grid_Manager;

    Path_Finder path_Finder;

    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        grid_Manager = FindObjectOfType<Grid_Manager>();

        path_Finder = FindObjectOfType<Path_Finder>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(grid_Manager != null)
        {
            coordinates = grid_Manager.Get_Coordinates_From_Position(transform.position);

            if(!isPlaceable)
            {
                grid_Manager.Block_Node(coordinates);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if( (grid_Manager.GetNode(coordinates).isWalkable)  && (!path_Finder.Will_Block_Path(coordinates)) )
        {
            if (isPlaceable)
            {
                Debug.Log("Placed here : " + transform.name);

                bool isTowerCreation_Successful = Tower_prefab.Create_Tower_Here(Tower_prefab, transform.position);

                // isPlaceable = !isPlaced;

                if (isTowerCreation_Successful)
                {
                    grid_Manager.Block_Node(coordinates);

                    path_Finder.Notify_Receivers();
                }
            }

        }
    }

}
