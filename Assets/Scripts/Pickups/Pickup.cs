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

	// Use this for initialization
	void Start ()
    {
        tf = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        spin();
	}

    void spin()
    {
        tf.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Stats>() != null)
        {
            onPickup(other.gameObject);
        }
    }

    protected virtual void onPickup(GameObject instigator)
    {
        Destroy(this.gameObject);
    }
}
