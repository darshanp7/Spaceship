using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudScore : MonoBehaviour
{
    public Text goldCount;
    public Text silverCount;
    public Text bronzeCount;

    private ScoreManager scoreManager;

    private void OnEnable()
    {
        ScoreManager.ScoreUpdated += UpdateHudScores;
    }

    private void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    //ScoreManager Calls this method upon Updation of Scores
    private void UpdateHudScores() 
    {
        //Query Scores and Update UI
        goldCount.text = scoreManager.GoldCount.ToString();
        silverCount.text = scoreManager.SilverCount.ToString();
        bronzeCount.text = scoreManager.BronzeCount.ToString();
    }

    private void OnDisable()
    {
        ScoreManager.ScoreUpdated -= UpdateHudScores;
    }
}
