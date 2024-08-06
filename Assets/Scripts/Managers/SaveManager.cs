using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    // Awake is called when the script instance is being loaded
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
    }

    public void SaveGameStats(GameStats gameStats)
    {
        string json = JsonUtility.ToJson(gameStats);
        string path = Application.persistentDataPath + "/gameStats.json";
        File.WriteAllText(path, json);
    }
    public GameStats LoadGameStats()
    {
        GameStats stats;
        string path = Application.persistentDataPath + "/gameStats.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            stats = JsonUtility.FromJson<GameStats>(json);
        }
        else
        {
            stats = new GameStats();
            SaveGameStats(stats);
        }
        return stats;
    }

    public void SavePlayerStats(PlayerStats playerStats)
    {
        string json = JsonUtility.ToJson(playerStats);
        string path = Application.persistentDataPath + "/playerStats.json";
        File.WriteAllText(path, json);
    }
    public PlayerStats LoadPlayerStats()
    {
        PlayerStats stats;
        string path = Application.persistentDataPath + "/playerStats.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            stats = JsonUtility.FromJson<PlayerStats>(json);
        }
        else
        {
            stats = new PlayerStats();
            SavePlayerStats(stats);
        }
        return stats;
    }


    public void SaveGameSettings(GameSettings gameSettings)
    {
        string json = JsonUtility.ToJson(gameSettings);
        string path = Application.persistentDataPath + "/gameSettings.json";
        File.WriteAllText(path, json);
    }
    public GameSettings LoadGameSettings()
    {
        GameSettings settings;
        string path = Application.persistentDataPath + "/gameSettings.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            settings = JsonUtility.FromJson<GameSettings>(json);
        }
        else
        {
            settings = new GameSettings();
            SaveGameSettings(settings);
        }
        return settings;
    }
}
