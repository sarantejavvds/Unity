using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Pool : MonoBehaviour
{
    public GameObject Enemy_Prefab;

    [SerializeField] [Range(0.1f, 30f)] float Spawn_Time = 1f;

    [SerializeField] [Range(1, 50)] int Pool_Size = 5;

    GameObject[] pool;

    void Populate_Pool()
    {
        pool = new GameObject[Pool_Size];

        for(int i = 0; i < pool.Length ; i++)
        {
            pool[i] = Instantiate(Enemy_Prefab, transform);

            pool[i].SetActive(false);
        }
    }

    void Awake()
    {
        Populate_Pool();
    }

    void Enable_Object_In_Pool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);

                return;
            }
        }
    }

    IEnumerator Spawn_Enemy()
    {
        while(true)
        {
            Enable_Object_In_Pool();

            yield return new WaitForSeconds(Spawn_Time);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn_Enemy()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
