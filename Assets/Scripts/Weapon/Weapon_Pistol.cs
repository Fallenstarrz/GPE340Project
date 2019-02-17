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
