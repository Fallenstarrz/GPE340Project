using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_MachineGun : Weapon
{

	// Use this for initialization
	void Start ()
    {
        currentWeaponType = weaponType.machineGun;
    }

    /// <summary>
    /// Shoot machine gun
    /// if we don't have enough ammo or our cooldown isn't up then don't shoot
    /// otherwise reduce ammo by 1, reset the cooldown and shoot
    /// </summary>
    /// <param name="stats"></param>
    public override void Shoot(Stats stats)
    {
        if (shootCooldownCurrent <= 0)
        {
            if (stats.machineGunAmmoCurrent > 0)
            {
                stats.machineGunAmmoCurrent -= 1;
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
    /// Add machine gun ammo
    /// </summary>
    /// <param name="stats"></param>
    public override void addAmmo(Stats stats)
    {
        if ((stats.machineGunAmmoCurrent + ammoToAdd) >= stats.machineGunAmmoMax)
        {
            stats.machineGunAmmoCurrent = stats.machineGunAmmoMax;
        }
        else
        {
            stats.machineGunAmmoCurrent += ammoToAdd;
        }
        base.addAmmo(stats);
    }
}
