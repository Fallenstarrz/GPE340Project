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
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public override void Shoot()
    {

        base.Shoot();
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
