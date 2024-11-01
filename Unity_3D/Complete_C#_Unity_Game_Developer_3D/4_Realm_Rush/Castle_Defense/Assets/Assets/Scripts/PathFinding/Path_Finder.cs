using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Path_Finder : MonoBehaviour
{
    public Vector2Int start_Coordinates;
    public Vector2Int Start_Coordinates {  get { return start_Coordinates; } }

    public Vector2Int destination_Coordinates;
    public Vector2Int Destination_Coordinates {  get { return destination_Coordinates; } }

    Node start_Node;

    Node destination_Node;

    Node current_Search_Node;

    Vector2Int[] directions = { Vector2Int.left, Vector2Int.right, Vector2Int.up, Vector2Int.down };

    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    Grid_Manager grid_Manager;

    Queue<Node> frontier = new Queue<Node>();

    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();

    void Awake()
    {
        grid_Manager = FindObjectOfType<Grid_Manager>();

        if(grid_Manager != null)
        {
            grid = grid_Manager.GRID;

            start_Node = grid[start_Coordinates];

            destination_Node = grid[destination_Coordinates];
        }

    }

    void Algorithm_BreadthFirstSearch()
    {
        start_Node.isWalkable = true;

        destination_Node.isWalkable = true;

        frontier.Clear();

        reached.Clear();

        bool isRunning = true;

        frontier.Enqueue(start_Node);

        reached.Add(start_Coordinates, start_Node);

        while((frontier.Count > 0) && (isRunning))
        {
            current_Search_Node = frontier.Dequeue();

            current_Search_Node.isExplored = true;

            Explore_Neighbours();

            if(current_Search_Node.Coordinates == destination_Coordinates)
            {
                isRunning = false;
            }
        }
    }

    void Algorithm_BreadthFirstSearch(Vector2Int coordinates)
    {
        start_Node.isWalkable = true;

        destination_Node.isWalkable = true;

        frontier.Clear();

        reached.Clear();

        bool isRunning = true;

        frontier.Enqueue(grid[coordinates]);

        reached.Add(coordinates, grid[coordinates]);

        while ((frontier.Count > 0) && (isRunning))
        {
            current_Search_Node = frontier.Dequeue();

            current_Search_Node.isExplored = true;

            Explore_Neighbours();

            if (current_Search_Node.Coordinates == destination_Coordinates)
            {
                isRunning = false;
            }
        }
    }

    void Explore_Neighbours()
    {
        List<Node> neighbours = new List<Node>();

        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighbour_Coordinates = current_Search_Node.Coordinates + direction;

            if(grid.ContainsKey(neighbour_Coordinates))
            {
                neighbours.Add(grid[neighbour_Coordinates]);
            }
        }

        foreach (Node neighbour in neighbours)
        {
            if((!reached.ContainsKey(neighbour.Coordinates)) && (neighbour.isWalkable))
            {
                neighbour.Connected_To = current_Search_Node;

                reached.Add(neighbour.Coordinates, neighbour);

                frontier.Enqueue(neighbour);
            }
        }

    }

    public List<Node> Get_New_Path()
    {

        return Get_New_Path(start_Coordinates);
    }

    public List<Node> Get_New_Path(Vector2Int coordinates)
    {
        grid_Manager.Reset_Nodes();

        Algorithm_BreadthFirstSearch(coordinates);

        return Build_Path();
    }

    // Start is called before the first frame update
    void Start()
    {

        Get_New_Path();
    }

    List<Node> Build_Path()
    {
        List<Node> path = new List<Node>();

        Node current_Node = destination_Node;

        path.Add(current_Node);

        current_Node.isPath = true;

        while(current_Node.Connected_To != null)
        {
            current_Node = current_Node.Connected_To;

            path.Add(current_Node);

            current_Node.isPath = true;
        }

        path.Reverse();

        return path;
    }


    public bool Will_Block_Path(Vector2Int coordinates)
    {
        if(grid.ContainsKey(coordinates))
        {
            bool previous_State = grid[coordinates].isWalkable;

            grid[coordinates].isWalkable = false;

            List<Node> new_Path = Get_New_Path();

            grid[coordinates].isWalkable = previous_State;

            if(new_Path.Count <= 1)
            {
                Get_New_Path();

                return true;
            }
        }

        return false;
    }

    public void Notify_Receivers()
    {
        BroadcastMessage("Find_Enemy_Path_Recalculated", false, SendMessageOptions.DontRequireReceiver);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
