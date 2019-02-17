using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Health : Pickup
{
    public float healAmount;

    /// <summary>
    /// Get referece to stats of the instigator
    /// check if their current health would exceed max
    /// if it does then set current to max
    /// otherwise heal by healAmount
    /// </summary>
    /// <param name="instigator">actor who entered trigger</param>
    protected override void onPickup(GameObject instigator)
    {
        Stats instigatorStats = instigator.GetComponent<Stats>();
        if (instigatorStats.healthCurrent + healAmount >= instigatorStats.healthMax)
        {
            instigatorStats.healthCurrent = instigatorStats.healthMax;
        }
        else
        {
            instigatorStats.healthCurrent += healAmount;
        }
        base.onPickup(instigator);
    }
}
