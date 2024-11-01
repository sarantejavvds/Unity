using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the Example Script to Spawn Multiple Objects one by one on Game Scene, when Game is Started.
// Give this Script to an Empty Game Object.

public class To_Make_Multiple_Objects_Spawn_at_Game_Start : MonoBehaviour
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

        Instantiate(Object, randomSpawn_Pos, Quaternion.identity); // Ball Spawns At Random Spawn point.

    }

    // Start is called before the first frame update
    void Start()
    {
      InvokeRepeating("SpawnObject", 1f, 2f); // Invokes "SpawnObject()" method repeatedly one after other.
    }

    // Update is called once per frame
    void Update()
    {

    }

}
