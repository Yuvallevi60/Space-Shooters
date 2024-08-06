using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using UnityEngine;

public class UpgradesMenu : MonoBehaviour
{
    public enum Upgrades
    {
        Strength,
        Defense,
        Health,
        HealRate
    }

    [SerializeField] private TMP_InputField strength;
    [SerializeField] private TMP_InputField defense;
    [SerializeField] private TMP_InputField health;
    [SerializeField] private TMP_InputField healRate;

    [SerializeField] private TextMeshProUGUI coinsAmount;

    private void OnEnable()
    {
        strength.text = GameManager.Instance.playerStats.Strength.ToString();
        defense.text = GameManager.Instance.playerStats.Defense.ToString();
        health.text = GameManager.Instance.playerStats.MaxHealth.ToString();
        healRate.text = GameManager.Instance.playerStats.HealRate.ToString();

        coinsAmount.text = GameManager.Instance.gameStats.TotalCoins.ToString();
    }

    public void Upgrade(int fieldValue)
    {
        float newValue = 1; 
        switch ((Upgrades)fieldValue)
        {
            case Upgrades.Strength:
                newValue += float.Parse(strength.text);
                strength.text = newValue.ToString();
                break;
            case Upgrades.Defense:
                newValue += float.Parse(defense.text);
                defense.text = newValue.ToString(); 
                break;
            case Upgrades.Health:
                newValue += float.Parse(health.text);
                health.text = newValue.ToString();
                break;
            case Upgrades.HealRate:
                newValue += float.Parse(healRate.text);
                healRate.text = newValue.ToString();
                break;
        }
        SaveUpgrades();
    }

    private void SaveUpgrades()
    {
        GameManager.Instance.playerStats.Strength = float.Parse(strength.text);
        GameManager.Instance.playerStats.Defense = float.Parse(defense.text);
        GameManager.Instance.playerStats.MaxHealth = float.Parse(health.text);
        GameManager.Instance.playerStats.HealRate = float.Parse(healRate.text);

        GameManager.Instance.UpdatePlayerStats();
    }


}
