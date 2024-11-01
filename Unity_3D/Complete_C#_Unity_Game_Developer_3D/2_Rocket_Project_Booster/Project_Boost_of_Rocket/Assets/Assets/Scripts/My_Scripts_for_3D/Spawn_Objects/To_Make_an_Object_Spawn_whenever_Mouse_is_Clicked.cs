using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the Example Script to Spawn Objects on Game Scene, whenever Mouse is Clicked.
// Give this Script to an Empty Game Object.

public class To_Make_an_Object_Spawn_whenever_Mouse_is_Clicked : MonoBehaviour
{
    public GameObject Object; // Give The Object that was Saved inside Prefab Folder, and Deactivate the Original Object on Game Scene.

    public Transform spawnPoint; // Position to Spawn the Object.

    public float max_X, max_Z;

    void SpawnObject() // To set a Spawn Point for the object "ball".
    {
        // Instantiate(ball, spawnPoint.position, Quaternion.identity); // At single Spawn point.

        float random_X = Random.Range(-max_X, max_X);

        float random_Z = Random.Range(-max_Z, max_Z);

        Vector3 randomSpawn_Pos = new Vector3(random_X, 10f, random_Z); // Random Spawn Positions in X&Z-axes.

        Instantiate(Object, randomSpawn_Pos, Quaternion.identity); // Object Spawns At Random Spawn point.

    }

    // Start is called before the first frame updatedd
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) // Left Mouse Button
        {
            Vector3 mouse_Pos = Input.mousePosition;  // When Mouse clicks, at that position ball will spawn

            mouse_Pos.z = 10f; // Z-axis Position.

            Vector3 spawn_Pos = Camera.main.ScreenToWorldPoint(mouse_Pos);  // Can be able to Interact with World Coordinates
                                                                            // with help of Mouse Coordinates.

            Instantiate(Object, spawn_Pos, Quaternion.identity);  // Instantiate the Spawn position of the Object.
        }


    }

}