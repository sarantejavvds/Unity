using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.SerializableAttribute]

public class Node // : MonoBehaviour
{
    public Vector2Int Coordinates;

    public bool isWalkable;

    public bool isExplored;

    public bool isPath;

    public Node Connected_To;

    public Node(Vector2Int _coordinates, bool _isWalkable)
    {
        this.Coordinates = _coordinates;

        this.isWalkable = _isWalkable;

        //this.isExplored = isExplored;
        //this.isPath = isPath;
        //Connected_To = connected_To;
    }

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

}
