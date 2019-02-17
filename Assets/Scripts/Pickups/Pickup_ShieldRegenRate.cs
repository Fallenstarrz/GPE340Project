using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_ShieldRegenRate : Pickup
{
    public float shieldRegenRateIncrease;

    /// <summary>
    /// Get reference to instigator's stats
    /// increase shield recharge rate
    /// </summary>
    /// <param name="instigator">actor who entered trigger</param>
    protected override void onPickup(GameObject instigator)
    {
        Stats instigatorStats = instigator.GetComponent<Stats>();
        instigatorStats.shieldRegenRate += shieldRegenRateIncrease;
        base.onPickup(instigator);
    }
}
