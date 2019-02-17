using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Pickup : Spawner
{
    public List<GameObject> pickupsList;

    protected override void pickObjectToSpawn()
    {
        int randomObject = Random.Range(0, pickupsList.Count);
        objectToSpawn = pickupsList[randomObject];
        base.pickObjectToSpawn();
    }
}
