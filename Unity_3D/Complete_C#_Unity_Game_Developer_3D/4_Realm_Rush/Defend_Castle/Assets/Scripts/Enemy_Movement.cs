using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(ENEMY))]
public class Enemy_Movement : MonoBehaviour
{
    public List<WayPoint> path = new List<WayPoint>();

    [SerializeField] [Range(0f, 5f)] float Speed = 1f;

    ENEMY enemy;

    void Find_Enemy_Path()
    {
        path.Clear();

        GameObject waypoints_Parent_Path = GameObject.FindGameObjectWithTag("ENEMY_PATH");

        foreach(Transform waypoint in waypoints_Parent_Path.transform)
        {
            WayPoint _waypoint = waypoint.GetComponent<WayPoint>();

            if (_waypoint != null)
            {
                path.Add(_waypoint);
            }
        }

    }

    void Return_To_StartPosition()
    {
        transform.position = path[0].transform.position;
    }

    void Enemy_FinishLine()
    {
        enemy.Steal_Gold();

        gameObject.SetActive(false);
    }

    IEnumerator Follow_Path()
    {
        foreach (WayPoint wp in path)
        {
            Debug.Log("Enemy is on " + wp.name);

            Vector3 Start_Position = transform.position;

            Vector3 End_Position = wp.transform.position;

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
        Find_Enemy_Path();

        Return_To_StartPosition();

        StartCoroutine(Follow_Path());
    }

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<ENEMY>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
