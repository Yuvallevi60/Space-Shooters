using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static MenuHandler;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField joystickSpeed;
    [SerializeField] private TMP_Dropdown joystickType;
    [SerializeField] private TMP_InputField spawnRate;
    [SerializeField] private TMP_InputField worldScale;

    private void OnEnable()
    {
        InitializedFields();
    }

    private void InitializedFields()
    {
        joystickType.value = GameManager.Instance.gameSettings.joystickType switch
        {
            JoystickType.Floating => 0,
            JoystickType.Dynamic => 1,
            _ => 0
        };
        joystickSpeed.text = GameManager.Instance.gameSettings.JoystickSpeed.ToString();
        spawnRate.text = GameManager.Instance.gameSettings.SpawnRate.ToString();
        worldScale.text = GameManager.Instance.gameSettings.WorldScale.ToString();
    }

    public void SetJoystickType(int joystickType)
    {
        GameManager.Instance.gameSettings.joystickType = joystickType switch
        {
            0 => JoystickType.Floating,
            1 => JoystickType.Dynamic,
            _ => JoystickType.Dynamic
        };
        GameManager.Instance.UpdateGameSettings();
    }

    public void SetJoystickSpeed(string joystickSpeed)
    {
        GameManager.Instance.gameSettings.JoystickSpeed = float.Parse(joystickSpeed);
        GameManager.Instance.UpdateGameSettings();
    }

    public void SetSpawnRate(string spawnRate)
    {
        GameManager.Instance.gameSettings.SpawnRate = float.Parse(spawnRate);
        GameManager.Instance.UpdateGameSettings();
    }

    public void SetWorldScale(string worldScale)
    {
        GameManager.Instance.gameSettings.WorldScale = float.Parse(worldScale);
        GameManager.Instance.UpdateGameSettings();
    }

    public void ResetGameSettings()
    {
        GameManager.Instance.ResetGameSettings();
        InitializedFields();
    }

}
