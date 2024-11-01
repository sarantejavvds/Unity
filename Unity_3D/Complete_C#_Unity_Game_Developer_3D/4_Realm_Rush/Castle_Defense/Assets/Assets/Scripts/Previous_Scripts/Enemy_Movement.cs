using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(ENEMY))]
public class Enemy_Movement : MonoBehaviour
{
    List<Node> path = new List<Node>();

    [SerializeField] [Range(0f, 5f)] float Speed = 1f;

    ENEMY enemy;

    Grid_Manager grid_Manager;

    Path_Finder path_Finder;

    void Awake()
    {
        enemy = GetComponent<ENEMY>();

        grid_Manager = FindObjectOfType<Grid_Manager>();

        path_Finder = FindObjectOfType<Path_Finder>();
    }
    void Find_Enemy_Path_Recalculated()
    {
        path.Clear();

        path = path_Finder.Get_New_Path();

    }

    void Find_Enemy_Path_Recalculated(bool reset_Path)
    {
        Vector2Int coordinates = new Vector2Int();

        if (reset_Path)
        {
            coordinates = path_Finder.Start_Coordinates;
        }
        else
        {
            coordinates = grid_Manager.Get_Coordinates_From_Position(transform.position);
        }

        StopAllCoroutines();

        path.Clear();

        path = path_Finder.Get_New_Path(coordinates);

        StartCoroutine(Follow_Path());

    }

    void Return_To_StartPosition()
    {
        transform.position = grid_Manager.Get_Position_From_Coordinates(path_Finder.Start_Coordinates);
    }

    void Enemy_FinishLine()
    {
        enemy.Steal_Gold();

        gameObject.SetActive(false);
    }

    IEnumerator Follow_Path()
    {
        for(int i = 1 ; i < path.Count ; i++)
        {
            Vector3 Start_Position = transform.position;

            Vector3 End_Position = grid_Manager.Get_Position_From_Coordinates(path[i].Coordinates);

            float travel_Percent = 0f;

            transform.LookAt(End_Position);

            while (travel_Percent < 1f)
            {
                travel_Percent += (Time.deltaTime * Speed);

                transform.position = Vector3.Lerp(Start_Position, End_Position, travel_Percent);

                yield return new WaitForEndOfFrame();
            }

            //  yield return new WaitForSeconds(Delay_Time);
        }

        Enemy_FinishLine();
    }

    void OnEnable()
    {
        Return_To_StartPosition();

        Find_Enemy_Path_Recalculated(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
