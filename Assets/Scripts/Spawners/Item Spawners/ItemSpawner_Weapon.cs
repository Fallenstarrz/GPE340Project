using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner_Weapon : ItemSpawner
{
    public List<GameObject> weaponsList;

    /// <summary>
    /// pick a random item from the list of weapons to spawn
    /// </summary>
    protected override void pickObjectToSpawn()
    {
        int randomObject = Random.Range(0, weaponsList.Count);
        objectToSpawn = weaponsList[randomObject];
        base.pickObjectToSpawn();
    }
}
