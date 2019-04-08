using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // This class is basically a reference that the menus can hold to call gameManager functions

    /// <summary>
    /// Return to main menu
    /// </summary>
    public void goToMainMenu()
    {
        GameManager.instance.returnToMainMenu();
    }

    /// <summary>
    /// Close the application
    /// </summary>
    public void closeGame()
    {
        GameManager.instance.exitApplication();
    }

    /// <summary>
    /// Unpause / Resume the game
    /// </summary>
    public void resumeGame()
    {
        GameManager.instance.pauseGame();
    }

    /// <summary>
    /// Reset the gamemanagers variables to default variables
    /// </summary>
    public void gameReset()
    {
        GameManager.instance.resetGame();
    }
}
