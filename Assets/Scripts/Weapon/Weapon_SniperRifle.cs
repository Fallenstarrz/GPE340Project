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
