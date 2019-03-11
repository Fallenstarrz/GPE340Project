using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorSpawner : MonoBehaviour
{
    public List<GameObject> actorToSpawn;
    public Vector3 scale;
    public float spawnRate;
    public Transform tf;

    // Use this for initialization
    void Start()
    {
        tf = GetComponent<Transform>();
        InvokeRepeating("spawnActor", 0.0f, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// spawn an actor at random from our list
    /// </summary>
    protected virtual void spawnActor()
    {
        int objectToSpawn = Random.Range(0, actorToSpawn.Count);
        Instantiate(actorToSpawn[objectToSpawn], tf.position, tf.rotation);
    }

    /// <summary>
    /// draw line that points to the forward direction of the spawner
    /// </summary>
    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(Vector3.zero, Vector3.forward * 0.75f);
    }
}
