using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Enemy : Spawner
{
    public GameObject enemy;

    protected override void pickObjectToSpawn()
    {
        objectToSpawn = enemy;
        base.pickObjectToSpawn();
    }
}
