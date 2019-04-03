using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public HUD hudReference;
    /// <summary>
    /// Reset Game to default state determined by game manager
    /// </summary>
    void Start()
    {
        GameManager.instance.headsUpDisplay = hudReference;
        GameManager.instance.resetGame();
    }
}
