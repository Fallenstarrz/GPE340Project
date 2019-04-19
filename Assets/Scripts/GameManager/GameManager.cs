using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int waveNumber;
    public int enemiesPerWave;
    public int currentEnemiesSpawned;
    public List<Pawn_AI> enemySpawned = new List<Pawn_AI>();
    public List<ActorSpawner_Enemy> enemySpawners;
    public int maxEnemiesSpawned;

    public int playerLivesCurrent;
    public int playerLivesMax;
    public GameObject spawnedPlayer;
    public ActorSpawner_Player playerSpawner;
    public HUD headsUpDisplay;

    public bool isGameOver;
    public bool isPaused;

    public SceneSwitcher sceneSwitcher;
    public Settings settings;

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
        settings.loadSettings();
        //resetGame();
    }

    /// <summary>
    /// update, only used to simplify spawning the player
    /// </summary>
    private void Update()
    {
        spawnNewPlayer();
    }

    /// <summary>
    /// reduce player lives by 1
    /// </summary>
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
        if (headsUpDisplay != null)
        {
            headsUpDisplay.gameOverMenu.SetActive(false);
            headsUpDisplay.pauseMenu.SetActive(false);
        }
        if (spawnedPlayer != null)
        {
            Destroy(spawnedPlayer);
        }
        waveNumber = 0;
        currentEnemiesSpawned = 0;
        maxEnemiesSpawned = 3;
        playerLivesCurrent = playerLivesMax;
        isGameOver = false;
        isPaused = false;
        clearWave();
        spawnNewPlayer();
        enemySpawned.Clear();
        checkNewWave();
    }

    /// <summary>
    /// Destroy all currently spawned enemy pawns
    /// </summary>
    public void clearWave()
    {
        foreach (var pawn in enemySpawned)
        {
            Destroy(pawn.gameObject);
        }
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
    }

    /// <summary>
    /// Returns to scene called "MainMenu"
    /// </summary>
    public void returnToMainMenu()
    {
        sceneSwitcher.switchScene("MainMenu");
    }

    /// <summary>
    /// check to see if we need to spawn a new wave
    /// </summary>
    public void checkNewWave()
    {
        if (enemySpawned.Count - 1 <= 0)
        {
            spawnNewWave();
        }
    }

    // spawn a new wave of enemies
    public void spawnNewWave()
    {
        waveNumber++;
        maxEnemiesSpawned += (enemiesPerWave * waveNumber);
        enemySpawned.Clear();
        if (enemySpawners.Count-1 >= 0)
        {
            for (int i = 0; i < maxEnemiesSpawned; i++)
            {
                enemySpawners[Random.Range(0, enemySpawners.Count - 1)].spawnActor();
            } 
        }
    }

    // spawn a new player
    public void spawnNewPlayer()
    {
        if (playerSpawner != null)
        {
            playerSpawner.spawnActor();
        }
    }
}