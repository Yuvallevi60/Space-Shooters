using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UpgradableStat
{
    public string Name;
    public float Value;
    public float MinValue;
    public float MaxValue;

    public UpgradableStat(string name, float minValue, float maxValue)
    {
        Name = name;
        Value = minValue;
        MinValue = minValue;
        MaxValue = maxValue;
    }

    // return 'false' if the stat is fully upgrade. otherwise, upgrade it and return 'ture'.
    public bool Upgrade(float increment)
    {
        if (Value == MaxValue)
            return false;
        Value = Mathf.Min(MaxValue, Value + increment);
        return true;
    }


}
