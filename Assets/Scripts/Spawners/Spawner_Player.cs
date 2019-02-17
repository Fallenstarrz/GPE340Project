using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Player : Spawner
{
    public GameObject player;

    protected override void pickObjectToSpawn()
    {
        objectToSpawn = player;
        base.pickObjectToSpawn();
    }
}
