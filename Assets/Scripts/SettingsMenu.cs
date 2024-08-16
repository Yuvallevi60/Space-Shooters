using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static MenuHandler;

public class SettingsMenu : MonoBehaviour
{   
    [SerializeField] private TMP_Dropdown joystickType;

    [SerializeField] private Slider joystickSpeedSlider;
    [SerializeField] private TextMeshProUGUI _joystickSpeed;

    [SerializeField] private Slider spawnRateSlider;
    [SerializeField] private TextMeshProUGUI _spawnRate;

    [SerializeField] private Slider worldScaleSlider;
    [SerializeField] private TextMeshProUGUI _worldScale;

    private bool _enabledChanges = false; // enable changes on the Main.GameSettings, other wise its valus will be changed by the sliders at the start.


    private void Start()
    {      
        joystickSpeedSlider.minValue = 5;
        joystickSpeedSlider.maxValue = 20;

        spawnRateSlider.minValue = 0.1f;
        spawnRateSlider.maxValue = 5;

        worldScaleSlider.minValue = 1;
        worldScaleSlider.maxValue = 3;

        _enabledChanges = true;

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

        joystickSpeedSlider.value = GameManager.Instance.gameSettings.JoystickSpeed;
        _joystickSpeed.text = joystickSpeedSlider.value.ToString();

        spawnRateSlider.value = GameManager.Instance.gameSettings.SpawnRate;
        _spawnRate.text = spawnRateSlider.value.ToString();

        worldScaleSlider.value = GameManager.Instance.gameSettings.WorldScale;
        _worldScale.text = worldScaleSlider.value.ToString();
    }

    public void SetJoystickType(int joystickType)
    {
        if (_enabledChanges)
        {
            GameManager.Instance.gameSettings.joystickType = joystickType switch
            {
                0 => JoystickType.Floating,
                1 => JoystickType.Dynamic,
                _ => JoystickType.Dynamic
            };
            GameManager.Instance.UpdateGameSettings();
        }
    }

    public void SetJoystickSpeed(Single joystickSpeed)
    {
        if (_enabledChanges)
        {
            GameManager.Instance.gameSettings.JoystickSpeed = joystickSpeed;
            _joystickSpeed.text = joystickSpeed.ToString();
            GameManager.Instance.UpdateGameSettings();
        }
    }

    public void SetSpawnRate(Single spawnRate)
    {
        if (_enabledChanges)
        {
            spawnRateSlider.value = (float)Math.Round(spawnRate, 1); // round it to the closest 0.1
            GameManager.Instance.gameSettings.SpawnRate = spawnRateSlider.value;
            _spawnRate.text = spawnRateSlider.value.ToString();
            GameManager.Instance.UpdateGameSettings();
        }
    }

    public void SetWorldScale(Single worldScale)
    {
        if (_enabledChanges)
        {
            GameManager.Instance.gameSettings.WorldScale = worldScale;
            _worldScale.text = worldScale.ToString();
            GameManager.Instance.UpdateGameSettings();
        }
    }

    // called by a UI button to reset all the fildes' values to the default
    public void ResetGameSettings()
    {
        GameManager.Instance.ResetGameSettings();
        InitializedFields();
    }
}
