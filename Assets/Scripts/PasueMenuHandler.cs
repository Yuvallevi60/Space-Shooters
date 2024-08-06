using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasueMenuHandler : MonoBehaviour
{
    // return to the game - exit 'pause mode'
    public void Continue()
    {
        EventManager.Instance.ToggleGamePause(false);
    }

    // end the game - same has 'game over'
    public void EndGame()
    {
        EventManager.Instance.ToggleGamePause(false);
        EventManager.Instance.GameOver();
    }
}
