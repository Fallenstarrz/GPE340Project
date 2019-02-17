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
            else
            {
                Debug.Log("Out Of Ammo For " + currentWeaponType);
            }
        }
    }

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
