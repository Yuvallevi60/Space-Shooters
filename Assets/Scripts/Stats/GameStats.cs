using System;

[Serializable]
public class GameStats
{
    public int RecordScore;
    public int TotalCoins;

    public GameStats() 
    { 
        RecordScore = 0;
        TotalCoins = 0;
    }
}
