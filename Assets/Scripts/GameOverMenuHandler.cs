using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject GameOverMenu; //UI object
    [SerializeField] private GameObject NewRecordText;

    private void OnEnable()
    {
        EventManager.Instance.OnGameOver += OpenMenu;
        EventManager.Instance.OnRecordBreak += ToggleNewRecordText;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnGameOver -= OpenMenu;
        EventManager.Instance.OnRecordBreak -= ToggleNewRecordText;
    }

    // active or deactive the menu
    public void OpenMenu()
    {
        GameOverMenu.SetActive(true);
    }

    // restart the game
    public void Restart()
    {
        EventManager.Instance.StartGame();
    }

    // return to the main menu
    public void EndGame()
    {
        GameOverMenu.SetActive(false);
        GameManager.Instance.EndGame();
    }

    public void ToggleNewRecordText(bool value)
    {
        NewRecordText.SetActive(value);
    }
}
