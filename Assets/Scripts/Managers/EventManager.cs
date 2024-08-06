using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
            Destroy(gameObject);
    }


    public event Action OnStartGame;
    public void StartGame()
    {
        OnStartGame?.Invoke();
    }


    public event Action<bool> OnToggleGamePause;
    public void ToggleGamePause(bool value)
    {
        OnToggleGamePause?.Invoke(value);
    }


    public event Action OnGameOver;
    public void GameOver()
    {
        OnGameOver?.Invoke();
    }


    // called when the player get score
    public event Action<int> OnScoreChanged;
    public void ScoreChanged(int score)
    {
        OnScoreChanged?.Invoke(score);
    }


    // called when the player collect money
    public event Action<int> OnMoneyChanged;
    public void MoneyChanged(int score)
    {
        OnMoneyChanged?.Invoke(score);
    }

    public event Action<bool> OnRecordBreak;
    public void RecordBreak(bool value)
    {
        OnRecordBreak?.Invoke(value);
    }
}
