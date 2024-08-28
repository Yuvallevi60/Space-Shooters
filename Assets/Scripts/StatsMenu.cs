using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gamesPlayed;
    [SerializeField] private TextMeshProUGUI recordScore;
    [SerializeField] private TextMeshProUGUI totalCoins;
    [SerializeField] private TextMeshProUGUI spendedCoins;
    [SerializeField] private TextMeshProUGUI enemiesKilled;


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
        gamesPlayed.text = $"Games Played: {GameManager.Instance.gameStats.GamesPlayed}";
        recordScore.text = $"Best Score: {GameManager.Instance.gameStats.RecordScore}";
        totalCoins.text = $"Total Coins: {GameManager.Instance.gameStats.TotalCoins}";
        spendedCoins.text = $"Spended Coins: {GameManager.Instance.gameStats.SpendedCoins}";
        enemiesKilled.text = $"Enemies Killed: {GameManager.Instance.gameStats.TotalEnemiesKilled}";
    }
}
