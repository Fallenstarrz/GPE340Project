using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // This class is basically a reference that the menus can hold to call gameManager functions

    public void goToMainMenu()
    {
        GameManager.instance.returnToMainMenu();
    }

    public void closeGame()
    {
        GameManager.instance.exitApplication();
    }

    public void resumeGame()
    {
        GameManager.instance.pauseGame();
    }

    public void gameReset()
    {
        GameManager.instance.resetGame();
    }
}
