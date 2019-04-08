using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Connector class used to store all HUD information
/// </summary>
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
    public InventorySlot[] weaponSlots = new InventorySlot[5];
    public TextMeshProUGUI currentAmmoInfo;
    public TextMeshProUGUI maxAmmoInfo;
}
