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
            else
            {
                Debug.Log("Out Of Ammo For " + currentWeaponType);
            }
        }
    }

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
