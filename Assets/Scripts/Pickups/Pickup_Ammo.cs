﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Ammo : Pickup
{
    public int ammoAmountToAdd;
    public enum ammoType
    {
        pistol,
        assaultRifle,
        machineGun,
        rocketLauncher,
        sniperRifle
    }
    public ammoType typeOfAmmo;

    /// <summary>
    /// set a reference to instigator stats
    /// then add the proper ammo type
    /// </summary>
    /// <param name="instigator">actor who entered trigger</param>
    protected override void onPickup(GameObject instigator)
    {
        Stats instigatorStats = instigator.GetComponent<Stats>();
        addAmmo(instigatorStats);
        base.onPickup(instigator);
    }

    /// <summary>
    /// Switch on the amount type
    /// </summary>
    /// <param name="stats">stats of the instigator, which is the actor who entered the trigger</param>
    protected void addAmmo(Stats stats)
    {
        switch (typeOfAmmo)
        {
            case ammoType.pistol:
                if ((stats.pistolAmmoCurrent + ammoAmountToAdd) >= stats.pistolAmmoMax)
                {
                    stats.pistolAmmoCurrent = stats.pistolAmmoMax;
                }
                else
                {
                    stats.pistolAmmoCurrent += ammoAmountToAdd;
                }
                break;
            case ammoType.assaultRifle:
                if ((stats.rifleAmmoCurrent + ammoAmountToAdd) >= stats.rifleAmmoMax)
                {
                    stats.rifleAmmoCurrent = stats.rifleAmmoMax;
                }
                else
                {
                    stats.rifleAmmoCurrent += ammoAmountToAdd;
                }
                break;
            case ammoType.machineGun:
                if ((stats.machineGunAmmoCurrent + ammoAmountToAdd) >= stats.machineGunAmmoMax)
                {
                    stats.machineGunAmmoCurrent = stats.machineGunAmmoMax;
                }
                else
                {
                    stats.machineGunAmmoCurrent += ammoAmountToAdd;
                }
                break;
            case ammoType.rocketLauncher:
                if ((stats.RocketLauncherAmmoCurrent + ammoAmountToAdd) >= stats.RocketLauncherAmmoMax)
                {
                    stats.RocketLauncherAmmoCurrent = stats.RocketLauncherAmmoMax;
                }
                else
                {
                    stats.RocketLauncherAmmoCurrent += ammoAmountToAdd;
                }
                break;
            case ammoType.sniperRifle:
                if ((stats.sniperAmmoCurrent + ammoAmountToAdd) >= stats.sniperAmmoMax)
                {
                    stats.sniperAmmoCurrent = stats.sniperAmmoMax;
                }
                else
                {
                    stats.sniperAmmoCurrent += ammoAmountToAdd;
                }
                break;
        }
    }
}
