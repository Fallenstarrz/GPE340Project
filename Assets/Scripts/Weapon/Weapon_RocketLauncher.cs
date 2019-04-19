using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_RocketLauncher : Weapon
{
	// Use this for initialization
	void Start ()
    {
        currentWeaponType = weaponType.rocketLauncher;
    }

    /// <summary>
    /// Shoot rocket launcher
    /// if we don't have enough ammo or our cooldown isn't up then don't shoot
    /// otherwise reduce ammo by 1, reset the cooldown and shoot
    /// </summary>
    /// <param name="stats"></param>
    public override void Shoot(Stats stats)
    {
        if (shootCooldownCurrent <= 0)
        {
            if (stats.RocketLauncherAmmoCurrent > 0)
            {
                stats.RocketLauncherAmmoCurrent -= 1;
                shootCooldownCurrent = shootCooldownMax;
                base.Shoot(stats);
            }
        }
    }

    /// <summary>
    /// Add rocket launcher ammo
    /// </summary>
    /// <param name="stats"></param>
    public override void addAmmo(Stats stats)
    {
        if ((stats.RocketLauncherAmmoCurrent + ammoToAdd) >= stats.RocketLauncherAmmoMax)
        {
            stats.RocketLauncherAmmoCurrent = stats.RocketLauncherAmmoMax;
        }
        else
        {
            stats.RocketLauncherAmmoCurrent += ammoToAdd;
        }
        base.addAmmo(stats);
    }
}
