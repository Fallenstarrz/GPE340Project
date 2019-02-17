using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Pistol : Weapon
{

    // Use this for initialization
    void Start ()
    {
        currentWeaponType = weaponType.pistol;
    }

    /// <summary>
    /// Shoot pistol
    /// if we don't have enough ammo or our cooldown isn't up then don't shoot
    /// otherwise reduce ammo by 1, reset the cooldown and shoot
    /// </summary>
    /// <param name="stats"></param>
    public override void Shoot(Stats stats)
    {
        if (shootCooldownCurrent <= 0)
        {
            if (stats.pistolAmmoCurrent > 0)
            {
                stats.pistolAmmoCurrent -= 1;
                shootCooldownCurrent = shootCooldownMax;
                base.Shoot(stats);
            }
            else
            {
                Debug.Log("Out Of Ammo For " + currentWeaponType);
            }
        }
    }

    /// <summary>
    /// Add Pistol ammo
    /// </summary>
    /// <param name="stats"></param>
    public override void addAmmo(Stats stats)
    {
        if ((stats.pistolAmmoCurrent + ammoToAdd) >= stats.pistolAmmoMax)
        {
            stats.pistolAmmoCurrent = stats.pistolAmmoMax;
        }
        else
        {
            stats.pistolAmmoCurrent += ammoToAdd;
        }
        base.addAmmo(stats);
    }
}
