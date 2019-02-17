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
