using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Pistol : Weapon
{

    // Use this for initialization
    void Start ()
    {
        currentWeaponType = weaponType.pistol;
    }

    public override void Shoot(Stats stats)
    {
        if (shootCooldownCurrent <= 0)
        {
            if (stats.pistolAmmoCurrent > 0)
            {
                stats.pistolAmmoCurrent -= 1;
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
        if ((stats.pistolAmmoCurrent + ammoToAdd) >= stats.pistolAmmoMax)
        {
            stats.pistolAmmoCurrent = stats.pistolAmmoMax;
        }
        else
        {
            stats.pistolAmmoCurrent += ammoToAdd;
        }
        base.addAmmo(stats);
    }
}
