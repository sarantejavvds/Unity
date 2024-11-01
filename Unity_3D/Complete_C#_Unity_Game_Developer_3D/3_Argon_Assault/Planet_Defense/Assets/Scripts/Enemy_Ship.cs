using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ship : MonoBehaviour
{
    [SerializeField] GameObject Enemy_death_Explosion;

    [SerializeField] GameObject Hit_VFX;

    public int Score_Per_Destroy_Enemy = 100;

    public int Hit_points_per_LaserHit = 10;

    GameObject parent_GameObject;

    ScoreBoard scoreBoard;


    void Add_RigidBody_To_Enemy()
    {
         Rigidbody rb = gameObject.AddComponent<Rigidbody>();

         rb.useGravity = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();

        parent_GameObject = GameObject.FindWithTag("Spawn_At_RunTime");

        Add_RigidBody_To_Enemy();       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Hit_Enemy()
    {
        GameObject vfx = Instantiate(Hit_VFX, transform.position, Quaternion.identity);

        vfx.transform.parent = parent_GameObject.transform;

        Hit_points_per_LaserHit--;
    }

    void Kill_Enemy()
    {
        scoreBoard.Increment_Score(Score_Per_Destroy_Enemy);

        GameObject vfx = Instantiate(Enemy_death_Explosion, transform.position, Quaternion.identity);

        vfx.transform.parent = parent_GameObject.transform;

        Destroy(gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log($" I'm hit!! by {other.gameObject.name} ");

        Hit_Enemy();

        if(Hit_points_per_LaserHit < 1)
        {
            Kill_Enemy();
        }

    }

}
