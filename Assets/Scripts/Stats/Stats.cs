using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
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

    [Header("Shields")]
    public float shieldMax;
    public float shieldCurrent;
    public Image shieldFill;
    public float shieldRegenRate;
    public float shieldRegenDelayCurrent;
    public float shieldRegenDelayMax;
    public Image shieldRegenFill;

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

    [Header("Buffs")]
    public List<Pickup> buffs = new List<Pickup>();

    // Set default stats on spawned
    void Start ()
    {
        healthCurrent = healthMax;
        staminaCurrent = staminaMax;
        shieldCurrent = shieldMax;
        pistolAmmoCurrent = pistolAmmoMax;
        sniperAmmoCurrent = 0;
        machineGunAmmoCurrent = 0;
        RocketLauncherAmmoCurrent = 0;
        rifleAmmoCurrent = 0;

        inventory[0] = startingWeapon;
	}

    private void Update()
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
    }

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

    // Update health UI
    void healthUIUpdate()
    {
        healthFill.fillAmount = healthCurrent / healthMax;
    }

    // Update stamina UI
    void staminaUIUpdate()
    {
        staminaFill.fillAmount = staminaCurrent / staminaMax;
    }

    // Update shield UI
    void shieldUIUpdate()
    {
        shieldFill.fillAmount = shieldCurrent / shieldMax;
    }

    // Update Stamina Regen UI
    void staminaUIRegenUpdate()
    {
        staminaRegenFill.fillAmount = 1 - (staminaRegenDelayCurrent / shieldRegenDelayMax);
    }

    // Update Shield Regen UI
    void shieldUIRegenUpdate()
    {
        shieldRegenFill.fillAmount = 1 - (shieldRegenDelayCurrent / shieldRegenDelayMax);
    }
}
