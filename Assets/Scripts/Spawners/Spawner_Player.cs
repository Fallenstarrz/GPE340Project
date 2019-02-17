using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Player : Spawner
{
    public GameObject player;

    /// <summary>
    ///  pick the player as the next object to spawn
    /// </summary>
    protected override void pickObjectToSpawn()
    {
        objectToSpawn = player;
        base.pickObjectToSpawn();
    }
}
