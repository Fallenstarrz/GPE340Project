using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Weapon : Pickup
{
    public Weapon weapon;

    protected override void onPickup(GameObject instigator)
    {
        Stats instigatorStats = instigator.GetComponent<Stats>();
        addToInventory(instigatorStats);
        base.onPickup(instigator);
    }

    void addToInventory(Stats stats)
    {
        for (int i = 0; i < stats.inventory.Length; i++)
        {
            if (stats.inventory[i] == weapon)
            {
                // Add ammo instead
                weapon.addAmmo(stats);
                break;
            }
            else if (stats.inventory[i] != null)
            {
                continue;
            }
            else
            {
                // add to inventory
                stats.inventory[i] = weapon;
                weapon.addAmmo(stats);
                break;
            }
        }
    }
}
