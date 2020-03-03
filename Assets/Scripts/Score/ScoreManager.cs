using System;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int GoldCount { get; private set; }
    public int SilverCount { get; private set; }
    public int BronzeCount { get; private set; }

    public static event Action ScoreUpdated;
    private bool isScoreUpdated;
    private void OnEnable()
    {
        SpaceshipEventsBroker.CaughtCollectibles += OnCaughtCollectible;
    }

    private void Start()
    {
        GoldCount = SilverCount = BronzeCount = 0;
    }

    private void OnCaughtCollectible(string collectibleTag)
    {
        if(collectibleTag == "Gold")
        {
            GoldCount += 1;
        }
        else if(collectibleTag == "Silver")
        {
            SilverCount += 1;
        }
        else if(collectibleTag == "Bronze")
        {
            BronzeCount += 1;
        }

        ScoreUpdated?.Invoke();
    }
    
    private void OnDisable()
    {
        SpaceshipEventsBroker.CaughtCollectibles -= OnCaughtCollectible;
    }
}
