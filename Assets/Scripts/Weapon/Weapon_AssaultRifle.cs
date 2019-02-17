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
