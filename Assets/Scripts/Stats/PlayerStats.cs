using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    public float Strength;
    public float Defense;

    public float MaxHealth;
    public float HealRate;
    public float AutoHealPrecent;


    public float HeartHealVal;
    public float MagnetDuration;
    public float ShieldHealth;

    public int CoinMinValue;
    public int CoinMaxValue;


    public PlayerStats()
    {
        Strength = 1;
        Defense = 1;

        MaxHealth = 10;
        HealRate = 1;

        MagnetDuration = 15;

        HeartHealVal = 2;
        AutoHealPrecent = 1;

        ShieldHealth = 2;

        CoinMinValue = 1;
        CoinMaxValue = 5;
    }
}
