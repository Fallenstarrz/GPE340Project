using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndRemoval : MonoBehaviour
{
    [Header("Timers")]
    [SerializeField]
    [Tooltip("Time in seconds to wait before destroying this object after spawn")]
    [Range(0,120)]
    private float timeBeforeDestroy;
    [SerializeField]
    [Tooltip("Time in seconds to wait before removing rigidbody and collider from this gameObject")]
    [Range(0,5)]
    private float timeBeforeRemove;
    Rigidbody myRigidbody;
    Collider myCollider;

    // Use this for initialization
    void Start()
    {

    }

    /// <summary>
    /// begin funtion is called and used the same way a start function would, but we don't want it to run on all objects, only the ones spawned by enemies,
    /// so we attach this to every object and run the function when the enemy dies instead
    /// </summary>
    public void begin()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myCollider = GetComponent<Collider>();
        Destroy(this.gameObject, timeBeforeDestroy);
        StartCoroutine(removeComponents());
    }

    /// <summary>
    /// Coroutine!!
    /// This function removes sets the collider to a trigger after it removes the rigidbody from the object,
    /// this is so objects cannot be pushed around after they have landed on the ground
    /// </summary>
    /// <returns></returns>
    IEnumerator removeComponents()
    {
        yield return new WaitForSeconds(timeBeforeRemove);

        Destroy(myRigidbody);
        myCollider.isTrigger = true;
    }

}
