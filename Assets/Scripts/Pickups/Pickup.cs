using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    private Transform tf;
    [Header("Rotation")]
    [SerializeField]
    [Range(0,360)]
    [Tooltip("Rate at which the object spins")]
    private int rotationSpeed;
    [SerializeField]
    private GameObject pickupParticles;

	// Use this for initialization
	void Start ()
    {
        tf = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager.instance.isPaused == false)
        {
            spin(); 
        }
	}

    /// <summary>
    /// Spin the object about the Y axis by rotationSpeed * time since last frame
    /// </summary>
    void spin()
    {
        tf.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    /// <summary>
    /// When a collider with the stats component collides with this pickup
    /// run the onPickup function for the children
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Stats>() != null)
        {
            if (other.gameObject == GameManager.instance.spawnedPlayer)
            {
                onPickup(other.gameObject);
                createParticles();
            }
        }
    }

    /// <summary>
    /// Destroy the pickup, so another one can spawn
    /// </summary>
    /// <param name="instigator">object that entered the trigger</param>
    protected virtual void onPickup(GameObject instigator)
    {
        Destroy(this.gameObject);
    }

    // Create particles
    private void createParticles()
    {
        Instantiate(pickupParticles , tf.position, pickupParticles.transform.rotation);
    }
}
