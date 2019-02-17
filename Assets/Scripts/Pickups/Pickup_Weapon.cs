using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Weapon : Pickup
{
    public Weapon weapon;

    /// <summary>
    /// Get reference to instigator's stats
    /// run addToInventory Function passing the stats reference as a parameter
    /// </summary>
    /// <param name="instigator">actor who entered trigger</param>
    protected override void onPickup(GameObject instigator)
    {
        Stats instigatorStats = instigator.GetComponent<Stats>();
        addToInventory(instigatorStats);
        base.onPickup(instigator);
    }

    /// <summary>
    /// Loop through inventory array from stats Class
    /// if inventoryItem is the weapon we want to add to inventory, run addAmmo function from the weapon class
    /// else if inventoryItem is empty don't check last condition and move to next iteration of the loop
    /// else it doesn't exist in the inventory and we must put a reference to the weapon there.
    /// </summary>
    /// <param name="stats">reference to instigators stats, instigator is actor who entered trigger</param>
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
