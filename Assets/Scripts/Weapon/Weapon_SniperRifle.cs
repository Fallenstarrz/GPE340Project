using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_SniperRifle : Weapon
{

	// Use this for initialization
	void Start ()
    {
        currentWeaponType = weaponType.sniperRifle;
    }

    /// <summary>
    /// Shoot sniper bullet
    /// reduce sniper ammo by 1
    /// if we don't have enough ammo or cooldown isn't up
    /// then we don't shoot
    /// </summary>
    /// <param name="stats"></param>
    public override void Shoot(Stats stats)
    {
        if (shootCooldownCurrent <= 0)
        {
            if (stats.sniperAmmoCurrent > 0)
            {
                stats.sniperAmmoCurrent -= 1;
                shootCooldownCurrent = shootCooldownMax;
                base.Shoot(stats);
            }
        }
    }

    /// <summary>
    /// Add sniper Ammo
    /// </summary>
    /// <param name="stats"></param>
    public override void addAmmo(Stats stats)
    {
        if ((stats.sniperAmmoCurrent + ammoToAdd) >= stats.sniperAmmoMax)
        {
            stats.sniperAmmoCurrent = stats.sniperAmmoMax;
        }
        else
        {
            stats.sniperAmmoCurrent += ammoToAdd;
        }
        base.addAmmo(stats);
    }
}
