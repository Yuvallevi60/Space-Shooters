using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    private int score;
    private int scoreToAdd;

    [SerializeField] private TextMeshProUGUI MoneyText;
    private int money;
    private int moneyToAdd;

    [SerializeField] private GameObject PauseMenu;


    private void OnEnable()
    {
        EventManager.Instance.OnScoreChanged += AddScore;
        EventManager.Instance.OnMoneyChanged += AddMoney;
        EventManager.Instance.OnToggleGamePause += TogglePauseMenu;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnScoreChanged -= AddScore;
        EventManager.Instance.OnScoreChanged -= AddScore;
        EventManager.Instance.OnToggleGamePause -= TogglePauseMenu;
    }

    public void Update()
    {
        if (scoreToAdd != 0)
        {
            score++;
            ScoreText.text = score.ToString();
            scoreToAdd--;
        }

        if (moneyToAdd > 0)
        {
            money++;
            MoneyText.text = money.ToString();
            moneyToAdd--;
        }
    }


    public void AddScore(int points)
    {
        scoreToAdd += points;
        GameManager.Instance.currentPlayStats.Score += points;
    }

    public void AddMoney(int amount)
    {
        moneyToAdd += amount;
        GameManager.Instance.currentPlayStats.Coins += amount;
    }

    public void TogglePauseMenu(bool toggle)
    {
        PauseMenu.SetActive(toggle);
    }
}
