using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_AssaultRifle : Weapon
{

	// Use this for initialization
	void Start ()
    {
        currentWeaponType = weaponType.assaultRifle;
    }

    /// <summary>
    /// Shoot rifle
    /// if we don't have enough ammo or our cooldown isn't up then don't shoot
    /// otherwise reduce ammo by 1, reset the cooldown and shoot
    /// </summary>
    /// <param name="stats"></param>
    public override void Shoot(Stats stats)
    {
        if (shootCooldownCurrent <= 0)
        {
            if (stats.rifleAmmoCurrent > 0)
            {
                stats.rifleAmmoCurrent -= 1;
                shootCooldownCurrent = shootCooldownMax;
                base.Shoot(stats);
            }
        }
    }

    /// <summary>
    /// Add rifle ammo
    /// </summary>
    /// <param name="stats"></param>
    public override void addAmmo(Stats stats)
    {
        if ((stats.rifleAmmoCurrent + ammoToAdd) >= stats.rifleAmmoMax)
        {
            stats.rifleAmmoCurrent = stats.rifleAmmoMax;
        }
        else
        {
            stats.rifleAmmoCurrent += ammoToAdd;
        }
        base.addAmmo(stats);
    }
}
