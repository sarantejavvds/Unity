using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    public GameObject ball;

    public Transform spawnPoint;

    public float max_X, max_Z;

    // Start is called before the first frame update
    void Start()
    {
       SpawnBall();  // Make the ball spawn whenever game is started.

      //InvokeRepeating("SpawnBall", 1f, 2f); // Invokes "SpawnBall()" method repeatedly one after other.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Checks when Space bar is pressed. 
        {
            SpawnBall(); // Spawns a Ball whenever a space bar is pressed
        }

        if (Input.GetMouseButton(0)) // Left Mouse Button
        {
            Vector3 mouse_Pos = Input.mousePosition;  // When Mouse clicks, at that position ball will spawn

            mouse_Pos.z = 10f; // Z-axis Position.

            Vector3 spawn_Pos = Camera.main.ScreenToWorldPoint(mouse_Pos);  // Can be able to Interact with World Coordinates
                                                                            // with help of Mouse Coordinates.

            Instantiate(ball, spawn_Pos, Quaternion.identity);  // Instantiate the Spawn position of the ball.
        }

    }

    void SpawnBall() // To set a Spawn Point for the object "ball".
    { 
      // Instantiate(ball, spawnPoint.position, Quaternion.identity); // At single Spawn point.

        float random_X = Random.Range(-max_X, max_X);

        float random_Z = Random.Range(-max_Z, max_Z);

        Vector3 randomSpawn_Pos = new Vector3(random_X, 10f, random_Z); // Random Spawn Positions.

        Instantiate(ball, randomSpawn_Pos, Quaternion.identity); // Ball Spawns At Random Spawn point.

    }

}
