using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using UnityEngine;

public class UpgradesMenu : MonoBehaviour
{
    // fields of upgrades
    [SerializeField] private TextMeshProUGUI strength;
    [SerializeField] private TextMeshProUGUI defense;
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI healRate;


    [SerializeField] private TextMeshProUGUI _coinsAmount;

    [SerializeField] private float _upgradePrice;
    [SerializeField] private float _upgradeValue;

    private void OnEnable()
    {
        strength.text = GameManager.Instance.playerStats.GetStat("Strength").ToString();
        defense.text = GameManager.Instance.playerStats.GetStat("Defense").ToString();
        health.text = GameManager.Instance.playerStats.GetStat("MaxHealth").ToString();
        healRate.text = GameManager.Instance.playerStats.GetStat("HealRate").ToString();

        _coinsAmount.text = GameManager.Instance.gameStats.TotalCoins.ToString();
    }

    public void Upgrade(string stateName)
    {
        GameManager.Instance.playerStats.CoinMaxValue = 20;
        if (CanUpgrade(_upgradePrice))
        {
            bool result = GameManager.Instance.playerStats.UpgradeStat(stateName, _upgradeValue);

            if (result)
            {
                GameManager.Instance.gameStats.TotalCoins -= _upgradePrice;
                SaveManager.Instance.SaveGameStats(GameManager.Instance.gameStats); // should change it to an event
                UpdateText();
            }
        }
    }


    private bool CanUpgrade(float value)
    {
        return (value <= GameManager.Instance.gameStats.TotalCoins);
    }

    private void UpdateText()
    {
        strength.text = GameManager.Instance.playerStats.GetStat("Strength").ToString();
        defense.text = GameManager.Instance.playerStats.GetStat("Defense").ToString();
        health.text = GameManager.Instance.playerStats.GetStat("MaxHealth").ToString();
        healRate.text = GameManager.Instance.playerStats.GetStat("HealRate").ToString();

        _coinsAmount.text = GameManager.Instance.gameStats.TotalCoins.ToString();

        GameManager.Instance.UpdatePlayerStats();
    }
}
