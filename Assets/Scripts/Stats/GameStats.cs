using System;
using UnityEngine;

[Serializable]
public class GameStats
{
    public int RecordScore;
    public float TotalCoins;

    public GameStats() 
    { 
        RecordScore = 0;
        TotalCoins = 0;
    }
}
