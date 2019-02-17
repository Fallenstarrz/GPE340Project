using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Enemy : Spawner
{
    public GameObject enemy;

    /// <summary>
    /// pick an enemy to spawn
    /// This can easily be expanded into a list if we have variations of enemies
    /// </summary>
    protected override void pickObjectToSpawn()
    {
        objectToSpawn = enemy;
        base.pickObjectToSpawn();
    }
}
