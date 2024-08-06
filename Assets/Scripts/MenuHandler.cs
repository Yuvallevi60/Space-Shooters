using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public enum MenuState
    {
        Main,
        Stats,
        Settings,
        Upgrades
    }

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject statsPage;
    [SerializeField] private GameObject settingsPage;
    [SerializeField] private GameObject upgradesPage;


    private void Start()
    {
        ShowMenu((int)MenuState.Main);
    }

    public void Play()
    {
        EventManager.Instance.StartGame();
    }

    public void ShowMenu(int pageValue)
    {
        MenuState newState = (MenuState)pageValue;
        mainMenu.SetActive(newState == MenuState.Main);
        statsPage.SetActive(newState == MenuState.Stats);
        settingsPage.SetActive(newState == MenuState.Settings);
        upgradesPage.SetActive(newState == MenuState.Upgrades);
    }
}
