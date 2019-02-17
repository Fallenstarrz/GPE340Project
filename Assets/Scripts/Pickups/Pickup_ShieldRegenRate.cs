using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_ShieldRegenRate : Pickup
{
    public float shieldRegenRateIncrease;

    protected override void onPickup(GameObject instigator)
    {
        Stats instigatorStats = instigator.GetComponent<Stats>();
        instigatorStats.shieldRegenRate += shieldRegenRateIncrease;
        base.onPickup(instigator);
    }
}
