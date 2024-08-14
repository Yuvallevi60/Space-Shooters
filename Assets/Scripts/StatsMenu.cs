using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recordScore;
    [SerializeField] private TextMeshProUGUI totalCoins;


    private void OnEnable()
    {
        SetStats();
    }

    public void ResetGameStats()
    {
        GameManager.Instance.playerStats = new PlayerStats();
        SaveManager.Instance.SavePlayerStats(GameManager.Instance.playerStats);

        GameManager.Instance.gameStats = new GameStats();
        SaveManager.Instance.SaveGameStats(GameManager.Instance.gameStats);

        SetStats();
    }

    private void SetStats()
    {
        recordScore.text = $"Best Score: {GameManager.Instance.gameStats.RecordScore}";
        totalCoins.text = $"Total Coins: {GameManager.Instance.gameStats.TotalCoins}";
    }
}
