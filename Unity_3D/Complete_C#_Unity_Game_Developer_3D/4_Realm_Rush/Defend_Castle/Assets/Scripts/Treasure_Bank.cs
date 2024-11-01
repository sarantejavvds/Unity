using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Treasure_Bank : MonoBehaviour
{
    public int Starting_Balance = 1000;

    int current_Balance;
    public int Current_Balance {  get { return current_Balance; } }

    public TextMeshProUGUI Display_Balance;

    void Update_GOLD_Display()
    {
        Display_Balance.text = "GOLD : " + current_Balance;
    }

    void Awake()
    {
        current_Balance = Starting_Balance;

        Update_GOLD_Display();
    }

    void Reload_Scene()
    {
        Scene current_Scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(current_Scene.buildIndex);
    }

    public void Deposit_GOLD(int Amount)
    {
        current_Balance += Mathf.Abs(Amount);

        Update_GOLD_Display();
    }
    
    public void Withdraw_GOLD(int Amount)
    {
        current_Balance -= Mathf.Abs(Amount);

        Update_GOLD_Display();

        if(current_Balance <= 0)
        {
            Reload_Scene();
        }

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
