using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stats : MonoBehaviour
{
    public Pawn pawn;

    [Header("Health")]
    public float healthMax;
    public float healthCurrent;
    public Image healthFill;

    [Header("Stamina")]
    public float staminaMax;
    public float staminaCurrent;
    public Image staminaFill;
    public float staminaRegenRate;
    public float staminaRegenDelayCurrent;
    public float staminaRegenDelayMax;
    public Image staminaRegenFill;
    public float staminaDrainSprinting;

    [Header("Shields")]
    public float shieldMax;
    public float shieldCurrent;
    public Image shieldFill;
    public float shieldRegenRate;
    public float shieldRegenDelayCurrent;
    public float shieldRegenDelayMax;
    public Image shieldRegenFill;

    [Header("Lives")]
    public TextMeshProUGUI lives;

    [Header("Ammo Display")]
    public TMPro.TextMeshProUGUI currentAmmoText;
    public TMPro.TextMeshProUGUI maxAmmoText;

    [Header("Pistol")]
    public int pistolAmmoMax;
    public int pistolAmmoCurrent;

    [Header("Sniper")]
    public int sniperAmmoMax;
    public int sniperAmmoCurrent;


    [Header("Machine Gun")]
    public int machineGunAmmoMax;
    public int machineGunAmmoCurrent;

    [Header("Rocket Launcher")]
    public int RocketLauncherAmmoMax;
    public int RocketLauncherAmmoCurrent;

    [Header("Rifle")]
    public int rifleAmmoMax;
    public int rifleAmmoCurrent;

    [Header("Inventory")]
    public Weapon startingWeapon;
    public Weapon weaponEquipped;
    public Weapon[] inventory = new Weapon[5];

    // TODO: Buffs: NYI, WIP. Milestone 4 goal
    //[Header("Buffs")]
    //public List<Pickup> buffs = new List<Pickup>();

    // Set default stats on spawned
    void Awake()
    {
        pawn = GetComponent<Pawn>();

        healthCurrent = healthMax;
        staminaCurrent = staminaMax;
        shieldCurrent = shieldMax;
        pistolAmmoCurrent = pistolAmmoMax;
        sniperAmmoCurrent = sniperAmmoMax / 2;
        machineGunAmmoCurrent = machineGunAmmoMax / 2;
        RocketLauncherAmmoCurrent = RocketLauncherAmmoMax / 2;
        rifleAmmoCurrent = rifleAmmoMax / 2;

        inventory[0] = startingWeapon;
    }

    private void Update()
    {
        if (GameManager.instance.isPaused == false)
        {
            // Regens
            regenStamina();
            regenShields();

            // UI Updates
            healthUIUpdate();
            staminaUIUpdate();
            shieldUIUpdate();
            staminaUIRegenUpdate();
            shieldUIRegenUpdate();
            livesUIUpdate();
            ammoUIUpdate();
        }
    }

    /// <summary>
    /// Regenerate stamina by rate * Time.deltaTime
    /// </summary>
    void regenStamina()
    {
        if (staminaRegenDelayCurrent >= 0)
        {
            staminaRegenDelayCurrent -= Time.deltaTime;
            return;
        }
        if (staminaRegenDelayCurrent <= 0)
        {
            if (staminaCurrent >= staminaMax)
            {
                return;
            }
            else if (staminaCurrent + (staminaRegenRate * Time.deltaTime) >= staminaMax)
            {
                staminaCurrent = staminaMax;
            }
            else
            {
                staminaCurrent += staminaRegenRate * Time.deltaTime;
            }
        }
    }

    /// <summary>
    /// Regenerate shields by rate * Time.deltaTime
    /// </summary>
    void regenShields()
    {
        if (shieldRegenDelayCurrent >= 0)
        {
            shieldRegenDelayCurrent -= Time.deltaTime;
            return;
        }
        if (shieldRegenDelayCurrent <= 0)
        {
            if (shieldCurrent >= shieldMax)
            {
                return;
            }
            else if (shieldCurrent + (shieldRegenRate * Time.deltaTime) >= shieldMax)
            {
                shieldCurrent = shieldMax;
            }
            else
            {
                shieldCurrent += shieldRegenRate * Time.deltaTime;
            }
        }
    }

    /// <summary>
    /// Reduce health or shield by damageToTake parameter
    /// If our health is less than or equal to 0 then kill the pawn
    /// </summary>
    /// <param name="damageToTake">Damage passed in by the projectile we were hit by</param>
    public void takeDamage(float damageToTake)
    {
        if (shieldCurrent <= 0)
        {
            healthCurrent -= damageToTake;
            if (healthCurrent <= 0)
            {
                pawn.die();
            }
        }
        else
        {
            shieldCurrent -= damageToTake;
            shieldRegenDelayCurrent = shieldRegenDelayMax;
        }
    }

    // Update lives UI
    private void livesUIUpdate()
    {
        if (lives != null)
        {
            lives.text = GameManager.instance.playerLivesCurrent.ToString();
        }
    }

    // Update health UI
    void healthUIUpdate()
    {
        if (healthFill != null)
        {
            healthFill.fillAmount = healthCurrent / healthMax;
        }
    }

    // Update stamina UI
    void staminaUIUpdate()
    {
        if (staminaFill != null)
        {
            staminaFill.fillAmount = staminaCurrent / staminaMax;
        }
    }

    // Update shield UI
    void shieldUIUpdate()
    {
        if (shieldFill != null)
        {
            shieldFill.fillAmount = shieldCurrent / shieldMax;
        }
    }

    // Update Stamina Regen UI
    void staminaUIRegenUpdate()
    {
        if (staminaRegenFill != null)
        {
            staminaRegenFill.fillAmount = 1 - (staminaRegenDelayCurrent / shieldRegenDelayMax);
        }
    }

    // Update Shield Regen UI
    void shieldUIRegenUpdate()
    {
        if (shieldRegenFill != null)
        {
            shieldRegenFill.fillAmount = 1 - (shieldRegenDelayCurrent / shieldRegenDelayMax);
        }
    }

    /// <summary>
    /// Update the inventory when new items to the inventory or when actor is spawned
    /// int j holds positions of our secondary set of arrays, this is used for performance, so we don't need to do a second loop when we don't need to move x and y in a 2D array
    /// loop through inventory
    /// if the inventory slot is not null then check if current slot iteration is the active weapon
    ///     if it is the active weapon then set 0 slot on HUD to this and set the keybind to the inventory slot iteration
    ///     if the active weapon is not then set hud slot j to this image and set the keybind the the inventory slot iteration
    /// if the inventory slot is null then deactivate the slot, so we don't clutter the UI
    /// </summary>
    public void inventoryUIUpdate()
    {
        HUD display = GameManager.instance.headsUpDisplay;
        int j = 1;
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null)
            {
                if (weaponEquipped != null)
                {
                    // Null Reference Thrown Here... Find out why..?
                    if (weaponEquipped.GetType() == inventory[i].GetType())
                    {
                        display.weaponSlots[0].slotImage.sprite = weaponEquipped.weaponSprite;
                        display.weaponSlots[0].keybindNumber.text = (i+1).ToString();
                        display.weaponSlots[0].gameObject.SetActive(true);
                    }
                    else
                    {
                        display.weaponSlots[j].slotImage.sprite = inventory[i].weaponSprite;
                        display.weaponSlots[j].keybindNumber.text = (i+1).ToString();
                        display.weaponSlots[j].gameObject.SetActive(true);
                        j++;
                    } 
                }
            }
            else
            {
                display.weaponSlots[i].gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// switch the ammo current and max displayed based on the current weapon we have equipped
    /// </summary>
    private void ammoUIUpdate()
    {
        if (currentAmmoText != null && maxAmmoText != null)
        {
            if (weaponEquipped.currentWeaponType == Weapon.weaponType.machineGun)
            {
                currentAmmoText.text = machineGunAmmoCurrent.ToString();
                maxAmmoText.text = machineGunAmmoMax.ToString();
            }
            else if (weaponEquipped.currentWeaponType == Weapon.weaponType.assaultRifle)
            {
                currentAmmoText.text = rifleAmmoCurrent.ToString();
                maxAmmoText.text = rifleAmmoMax.ToString();
            }
            else if (weaponEquipped.currentWeaponType == Weapon.weaponType.rocketLauncher)
            {
                currentAmmoText.text = RocketLauncherAmmoCurrent.ToString();
                maxAmmoText.text = RocketLauncherAmmoMax.ToString();
            }
            else if (weaponEquipped.currentWeaponType == Weapon.weaponType.sniperRifle)
            {
                currentAmmoText.text = sniperAmmoCurrent.ToString();
                maxAmmoText.text = sniperAmmoMax.ToString();
            }
            else
            {
                currentAmmoText.text = pistolAmmoCurrent.ToString();
                maxAmmoText.text = pistolAmmoMax.ToString();
            } 
        }
    }
}
