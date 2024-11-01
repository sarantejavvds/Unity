using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TOWER : MonoBehaviour
{
    public int Cost_to_Deploy_Ballista = 75;

    public float Build_Time_When_Deployed = 1f;


    IEnumerator Build_Tower()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);

            foreach (Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(false);
            }
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);

            yield return new WaitForSeconds(Build_Time_When_Deployed);

            foreach (Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(true);
            }
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Build_Tower());
    }

    public bool Create_Tower_Here(TOWER tower, Vector3 position)
    {
        Treasure_Bank bank = FindObjectOfType<Treasure_Bank>();

        if (bank == null)
        {
            return false;
        }
        if (bank.Current_Balance >= Cost_to_Deploy_Ballista)
        {
            Instantiate(tower, position, Quaternion.identity);

            bank.Withdraw_GOLD(Cost_to_Deploy_Ballista);

            return true;
        }

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
