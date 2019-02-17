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

    protected virtual void pickObjectToSpawn()
    {

    }
}
