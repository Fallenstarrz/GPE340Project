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

    public void begin()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myCollider = GetComponent<Collider>();
        Destroy(this.gameObject, timeBeforeDestroy);
        StartCoroutine(removeComponents());
    }

    IEnumerator removeComponents()
    {
        yield return new WaitForSeconds(timeBeforeRemove);

        Destroy(myRigidbody);
        myCollider.isTrigger = true;
    }

}
