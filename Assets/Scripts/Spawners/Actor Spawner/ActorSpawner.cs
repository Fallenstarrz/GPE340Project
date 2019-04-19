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
        //InvokeRepeating("spawnActor", 1.0f, spawnRate);
    }

    /// <summary>
    /// spawn an actor at random from our list
    /// </summary>
    public virtual void spawnActor()
    {
        GameObject newObject;
        int objectToSpawn = Random.Range(0, actorToSpawn.Count);
        newObject = Instantiate(actorToSpawn[objectToSpawn], tf.position, tf.rotation);
        if (newObject.GetComponent<AIController>() != null)
        {
            newObject.GetComponent<AIController>().spawnPosition = this.transform.position;
        }
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
