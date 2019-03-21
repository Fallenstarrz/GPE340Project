using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int waveNumber;
    public int currentEnemiesSpawned;
    public int maxEnemiesSpawned;

    public int playerLivesCurrent;
    public int playerLivesMax;
    public GameObject spawnedPlayer;
    public HUD headsUpDisplay;

    public bool isGameOver;
    public bool isPaused;

    // Use this for initialization
    void Awake()
    {
        // Singleton game manager
        #region Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        } 
        #endregion
    }

    // Use this for initialization
    void Start()
    {

    }

    public void reducePlayerLives()
    {
        playerLivesCurrent--;
    }

    /// <summary>
    /// Sets game over
    /// </summary>
    public void gameOver()
    {
        if (playerLivesCurrent < 0)
        {
            headsUpDisplay.gameOverMenu.SetActive(true);
            isGameOver = true;
        }
    }

    /// <summary>
    /// Reset all values to default gane details
    /// </summary>
    public void resetGame()
    {
        headsUpDisplay.gameOverMenu.SetActive(false);
        headsUpDisplay.pauseMenu.SetActive(false);
        Destroy(spawnedPlayer);
        waveNumber = 0;
        currentEnemiesSpawned = 0;
        maxEnemiesSpawned = 3;
        playerLivesCurrent = playerLivesMax;
        isGameOver = false;
        isPaused = false;
    }

    /// <summary>
    /// Determines activity when game is paused
    /// </summary>
    public void pauseGame()
    {
        if (isPaused == false)
        {
            isPaused = true;
            Time.timeScale = 0.0f;
            headsUpDisplay.pauseMenu.SetActive(true);
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1.0f;
            headsUpDisplay.pauseMenu.SetActive(false);
        }
    }

    /// <summary>
    /// Close game completely
    /// </summary>
    public void exitApplication()
    {
        Application.Quit();
        // TODO: On Build Remove This Code
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void returnToMainMenu()
    {
        // Load main menu scene
    }
}

