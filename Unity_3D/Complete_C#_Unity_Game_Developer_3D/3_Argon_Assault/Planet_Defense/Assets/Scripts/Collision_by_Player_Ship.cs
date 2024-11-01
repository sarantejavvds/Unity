using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision_by_Player_Ship : MonoBehaviour
{
    [Header("Delay to Load")]
    [Tooltip("A certain Delay before Invoking Reload_Level method")] 
    public float Load_to_Delay = 1f;

    [Header("Particle System")]
    [Tooltip("Give Explosion Particle here as Input, when Player got Exploded")]
    public ParticleSystem Crash_VFX;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Reload_Level()
    {
        int current_Scene_Index = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(current_Scene_Index);
    }

    void Start_when_Crashed()
    {
        Crash_VFX.Play();

        GetComponent<MeshRenderer>().enabled = false;

        GetComponent<HERO_Ship_Controls>().enabled = false;

        GetComponent<BoxCollider>().enabled = false;

        Invoke("Reload_Level", Load_to_Delay);

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($" {this.name} is Triggered by  {other.gameObject.name} ");

        Start_when_Crashed();

    }

}
