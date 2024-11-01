using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_Manager : MonoBehaviour
{
    // public Node node;

    [Tooltip("World's Grid size in Unity which should match with Editor's Snap Settings")]
    public int unity_World_GridSize = 10;
    public int Unity_World_GridSize { get { return unity_World_GridSize; } }

    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> GRID { get { return grid; } }

    public Vector2Int grid_Size;

    public Node GetNode(Vector2Int Co_Ordinates)
    {
        if(grid.ContainsKey(Co_Ordinates))
        {
            return grid[Co_Ordinates];
        }

        return null;
    }

    void Create_Grid()
    {
        for(int x = 0 ; x < grid_Size.x ; x++)
        {
            for(int y = 0 ; y < grid_Size.y ; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);

                grid.Add(coordinates, new Node(coordinates, true));

              //  Debug.Log(grid[coordinates].Coordinates + " and "  + grid[coordinates].isWalkable);
            }
        }
    }

    void Awake()
    {
        Create_Grid();
    }

    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log(node.coordinates);
        
      //  Debug.Log(node.isWalkable);
    }

    public void Block_Node(Vector2Int coordinates)
    {
        if(grid.ContainsKey(coordinates))
        {
            grid[coordinates].isWalkable = false;
        }
    }

    public Vector2Int Get_Coordinates_From_Position(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();

        coordinates.x = Mathf.RoundToInt(position.x / unity_World_GridSize);

        coordinates.y = Mathf.RoundToInt(position.z / unity_World_GridSize);

        return coordinates;
    }

    public Vector3 Get_Position_From_Coordinates(Vector2Int coordinates)
    {
        Vector3 position = new Vector3();

        position.x = coordinates.x * unity_World_GridSize;

        position.z = coordinates.y * unity_World_GridSize;

        return position;
    }

    public void Reset_Nodes()
    {
        foreach(KeyValuePair<Vector2Int, Node> entry in grid)
        {
            entry.Value.Connected_To = null ;

            entry.Value.isExplored = false;

            entry.Value.isPath = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
