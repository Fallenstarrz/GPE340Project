using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Weapon : Spawner
{
    public List<GameObject> weaponsList;

    protected override void pickObjectToSpawn()
    {
        int randomObject = Random.Range(0, weaponsList.Count);
        objectToSpawn = weaponsList[randomObject];
        base.pickObjectToSpawn();
    }
}
