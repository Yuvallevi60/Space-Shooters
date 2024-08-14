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
}
