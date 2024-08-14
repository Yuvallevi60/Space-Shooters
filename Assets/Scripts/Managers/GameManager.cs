using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerStats playerStats;
    public GameSettings gameSettings;
    public GameStats gameStats;
    public CurrentPlayStats currentPlayStats;

    public bool isPlaying;
    public bool isPaused;

    // Awake is called when the script is being loaded
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        gameSettings = SaveManager.Instance.LoadGameSettings();
        gameStats = SaveManager.Instance.LoadGameStats();
        playerStats = SaveManager.Instance.LoadPlayerStats();
    }

    private void OnEnable()
    {
        EventManager.Instance.OnToggleGamePause += ToggleGamePause;
        EventManager.Instance.OnGameOver += GameOver;
        EventManager.Instance.OnStartGame += StartGame;
    }
    private void OnDisable()
    {
        EventManager.Instance.OnToggleGamePause -= ToggleGamePause;
        EventManager.Instance.OnGameOver -= GameOver;
        EventManager.Instance.OnStartGame -= StartGame;
    }


    private void Update()
    {
        if (UnityEngine.Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPlaying)
                EventManager.Instance.ToggleGamePause(!isPaused);
            else
                ExitGame();
        }
    }

    public void StartGame()
    {
        currentPlayStats = new CurrentPlayStats();
        isPlaying = true;
        SceneManager.LoadScene(1);
        Time.timeScale = 1; // in case it was pause/game-over
    }

    // Pause and realese game
    public void ToggleGamePause(bool value)
    {
        isPaused = value;
        Time.timeScale = isPaused ? 0 : 1;
    }



    // called when the player lose the game or end it menuly
    public void GameOver()
    {
        UpdateGameStats();
        Time.timeScale = 0;
    }

    // called when the plyer is lose the game
    public void EndGame()
    {
        Time.timeScale = 1;
        isPlaying = false;
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    // after end of a game the method update the GameStats 
    private void UpdateGameStats()
    {
        if (currentPlayStats.Score > gameStats.RecordScore)
        {
            gameStats.RecordScore = currentPlayStats.Score;
            EventManager.Instance.RecordBreak(true);
        }
        else 
        {
            EventManager.Instance.RecordBreak(false);
        }

        gameStats.TotalCoins += currentPlayStats.Coins;

        SaveManager.Instance.SaveGameStats(gameStats); 
    }

    public void UpdateGameSettings()
    {
        SaveManager.Instance.SaveGameSettings(gameSettings);
    }

    // return the game settings to defualt
    public void ResetGameSettings()
    {
        gameSettings = new GameSettings();
        UpdateGameSettings();
    }

    // after buying an upgrade
    public void UpdatePlayerStats()
    {
        SaveManager.Instance.SavePlayerStats(playerStats);
    }
}
