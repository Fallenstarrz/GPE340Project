﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public Image healthBar;
    public Image shieldBar;
    public Image staminaBar;
    public Image shieldRechargeBar;
    public Image staminaRechargeBar;
    public TextMeshProUGUI currentLives;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public Image[] weaponSlots = new Image[5];
}