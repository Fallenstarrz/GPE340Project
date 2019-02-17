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
