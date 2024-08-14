using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class PlayerStats
{
    public List<UpgradableStat> upgradableStats;

    public float AutoHealPrecent;

    public float HeartHealVal;
    public float MagnetDuration;
    public float ShieldHealth;

    public int CoinMinValue;
    public int CoinMaxValue;


    public PlayerStats()
    {
        InitializeUpgradableStats();

        MagnetDuration = 15;

        HeartHealVal = 2;
        AutoHealPrecent = 1;

        ShieldHealth = 2;

        CoinMinValue = 1;
        CoinMaxValue = 5;
    }

    private void InitializeUpgradableStats()
    {
        upgradableStats = new List<UpgradableStat>
        {
            new ("Strength", 1, 5),
            new ("Defense", 1, 5),
            new ("MaxHealth", 10, 20),
            new ("HealRate", 1, 5)
        };
    }

    public float GetStat(string name)
    {
        var stat = upgradableStats.FirstOrDefault(s => s.Name == name);
        if (stat != null)
            return stat.Value;
        else
            throw new ArgumentException($"Stat with name {name} not found.");
    }

    public bool UpgradeStat(string name, float value)
    {
        var stat = upgradableStats.FirstOrDefault(s => s.Name == name);
        if (stat != null)
            return stat.Upgrade(value);
        else
            throw new ArgumentException($"Stat with name {name} not found.");
    }
}

