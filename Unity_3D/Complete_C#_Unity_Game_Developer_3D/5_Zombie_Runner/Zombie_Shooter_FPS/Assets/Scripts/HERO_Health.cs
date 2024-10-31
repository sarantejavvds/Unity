using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HERO_Health : MonoBehaviour
{
    //[SerializeField] [Min(0f)] 
    public float Health_Points_of_HERO = 500f;

    public TextMeshProUGUI current_Health_of_HERO_Text;

    // Start is called before the first frame update
    void Start()
    {
        Health_Points_of_HERO = Mathf.Max(0f, Health_Points_of_HERO);
    }

    public void Damage_Taken_by_HERO_from_Zombie_Attack(float damage_by_Zombie)
    {
        Health_Points_of_HERO -= damage_by_Zombie;

        if(Health_Points_of_HERO <= 0)
        {
            GetComponent<Hero_Death_Handler>().Player_Death_Handler();

            Debug.Log("YOU ARE DEAD ...");
        }
    }

    public void Display_HERO_Health()
    {
        float current_Health = Health_Points_of_HERO;

        current_Health_of_HERO_Text.text = $"Your Health : {current_Health} ";
    }

    // Update is called once per frame
    void Update()
    {
        Display_HERO_Health();
    }
    
}
