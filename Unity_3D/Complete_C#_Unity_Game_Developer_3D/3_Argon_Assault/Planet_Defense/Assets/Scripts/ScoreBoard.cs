using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{

    int score;

    TMP_Text  Score_Text;

    // Start is called before the first frame update
    void Start()
    {
        Score_Text = GetComponent<TMP_Text>();

        Score_Text.text = "Start";
    }

    public void Increment_Score(int Amount_to_Increment_score)
    {
        score += Amount_to_Increment_score;

        Debug.Log($"Score is Now : {score} ");

        Score_Text.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
