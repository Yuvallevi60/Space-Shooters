using System;
using UnityEngine;

[Serializable]
public class GameStats
{
    public int GamesPlayed;
    public int RecordScore;
    public float TotalCoins;
    public float SpendedCoins;
    public int TotalEnemiesKilled;

    public GameStats() 
    {
        GamesPlayed = 0;
        RecordScore = 0;
        TotalCoins = 0;
        TotalEnemiesKilled = 0;
    }
}
