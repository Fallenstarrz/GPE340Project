using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_StaminaRegenRate : Pickup
{
    public float staminaRegenRateIncrease;

    /// <summary>
    /// Get reference to instigator's stats
    /// increase stamina recharge rate
    /// </summary>
    /// <param name="instigator">actor who entered trigger</param>
    protected override void onPickup(GameObject instigator)
    {
        Stats instigatorStats = instigator.GetComponent<Stats>();
        instigatorStats.staminaRegenRate += staminaRegenRateIncrease;
        base.onPickup(instigator);
    }
}
