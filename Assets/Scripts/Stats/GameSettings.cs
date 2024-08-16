using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameSettings
{
    public JoystickType joystickType;
    public float JoystickSpeed; 
    public float SpawnRate;
    public float WorldScale;

    public GameSettings()
    {
        joystickType = JoystickType.Dynamic;

        JoystickSpeed = 8;

        SpawnRate = 3;

        WorldScale = 1;
    }

    public override string ToString()
    {
        string str = string.Empty;

        str += "joystickType: " + joystickType.ToString() + "\t";
        str += "JoystickSpeed: " + JoystickSpeed.ToString() + "\t";
        str += "SpawnRate: " + SpawnRate.ToString() + "\t";
        str += "WorldScale: " + WorldScale.ToString();

        return str;
    }
}
