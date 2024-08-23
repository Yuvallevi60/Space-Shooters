using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesMenu : MonoBehaviour
{

    [SerializeField] private Transform updateTamplate;
    [SerializeField] private Transform updatesContainer;

    [SerializeField] private TextMeshProUGUI _coinsAmount;

    [SerializeField] private float _upgradePrice;
    [SerializeField] private float _upgradeValue;


    private void Awake()
    {
        updateTamplate.gameObject.SetActive(false);   
    }

    private void OnEnable()
    {
        foreach (UpgradableStat stat in GameManager.Instance.playerStats.upgradableStats)
            CerateUpgradeField(stat);
        _coinsAmount.text = GameManager.Instance.gameStats.TotalCoins.ToString();
    }

    private void OnDisable()
    {
        foreach (Transform child in updatesContainer)
            Destroy(child.gameObject);
    }


    private void CerateUpgradeField(UpgradableStat upgradeStat)
    {
        Transform upgrdeTransform = Instantiate(updateTamplate, updatesContainer);
        upgrdeTransform.gameObject.SetActive(true);

        upgrdeTransform.Find("Name").GetComponent<TextMeshProUGUI>().SetText(upgradeStat.Name);

        TextMeshProUGUI value = upgrdeTransform.Find("Value").GetComponent<TextMeshProUGUI>();
        value.SetText(upgradeStat.Value.ToString());

        Slider sliderTransform = upgrdeTransform.Find("Slider").GetComponent<Slider>();
        sliderTransform.minValue = upgradeStat.MinValue;
        sliderTransform.maxValue = upgradeStat.MaxValue;
        sliderTransform.value = upgradeStat.Value;

        Button button = upgrdeTransform.Find("Button").GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            if (TryUpgrade(upgradeStat.Name)) // return true if the stat upgraded
            {
                value.text = upgradeStat.Value.ToString();
                sliderTransform.value++;
            }
        });
    }


    private bool TryUpgrade(string stateName)
    {
        if (_upgradePrice > GameManager.Instance.gameStats.TotalCoins)
            return false;

        bool result = GameManager.Instance.playerStats.UpgradeStat(stateName, _upgradeValue); // check if stat exists and NOT updated to its max
        if (result) 
        {
            GameManager.Instance.gameStats.TotalCoins -= _upgradePrice;
            SaveManager.Instance.SaveGameStats(GameManager.Instance.gameStats); // should change it to an event

            _coinsAmount.text = GameManager.Instance.gameStats.TotalCoins.ToString();

            GameManager.Instance.UpdatePlayerStats();
        }
        return result;
    }
}
