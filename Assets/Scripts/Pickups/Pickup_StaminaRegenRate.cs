using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_StaminaRegenRate : Pickup
{
    public float staminaRegenRateIncrease;

    protected override void onPickup(GameObject instigator)
    {
        Stats instigatorStats = instigator.GetComponent<Stats>();
        instigatorStats.staminaRegenRate += staminaRegenRateIncrease;
        base.onPickup(instigator);
    }
}
