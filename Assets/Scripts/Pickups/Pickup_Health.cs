using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Health : Pickup
{
    public float healAmount;

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
