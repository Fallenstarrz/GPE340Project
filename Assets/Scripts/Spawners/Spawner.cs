using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    protected Transform tf;
    public GameObject spawnedObject;
    public GameObject objectToSpawn;

    public float spawnTimeCurrent;
    public float spawnTimeMax;
    public bool spawnAtStart;

	// Use this for initialization
    /// <summary>
    /// If we want to spawn at start set currentSpawnTime to 0
    /// otherwise set it to max spawn time
    /// then pick the next object to spawn
    /// </summary>
    void Start ()
    {
        tf = GetComponent<Transform>();
        if (spawnAtStart == true)
        {
            spawnTimeCurrent = 0;
        }
        else
        {
            spawnTimeCurrent = spawnTimeMax;
        }
        pickObjectToSpawn();
    }
	
	// Update is called once per frame
    /// <summary>
    /// if there is no object currently spawned reduce spawn time current, so we can start spawning after a delay
    /// if there is no object spawned and our delay is 0 then spawn a new one
    /// finally pick the next object to spawn
    /// </summary>
	void Update ()
    {
        if (spawnedObject == null)
        {
            if (spawnTimeCurrent >= 0)
            {
                spawnTimeCurrent -= Time.deltaTime;
            }
        }
        // if the spawn time is less than or equal to 0, spawn a pickup
        if (spawnTimeCurrent <= 0)
        {
            if (objectToSpawn != null)
            {
                spawnTimeCurrent = spawnTimeMax;
                spawnedObject = Instantiate(objectToSpawn, tf.position, tf.rotation);
                pickObjectToSpawn();
            }
        }
    }

    /// <summary>
    /// Pick the next object to spawn
    /// Chosen in children
    /// </summary>
    protected virtual void pickObjectToSpawn()
    {

    }
}
