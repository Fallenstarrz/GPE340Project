﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Weapon weaponThatShot;

    protected Rigidbody rb;

    protected Transform tf;

	// Use this for initialization
    /// <summary>
    /// Set up references
    /// Destroy object after lifespan in case it escapes the level without colliding
    /// set layer of the object, so it doesn't collide with same layers
    /// propel the projectile
    /// </summary>
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();

        Destroy(gameObject, weaponThatShot.projectileLifespan);

        gameObject.layer = weaponThatShot.gameObject.layer;
        propelBullet();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    /// <summary>
    /// Add force to the bullet propeling it forward
    /// Vector3.Right is used because of the weapon import settings were adjusted
    /// </summary>
    void propelBullet()
    {
        rb.AddRelativeForce(Vector3.right * weaponThatShot.bulletSpeed, ForceMode.VelocityChange);
    }

    /// <summary>
    /// destroy the projectile's gameobject, so it doesn't exist longer than it needs to on collision
    /// </summary>
    /// <param name="collision"></param>
    protected virtual void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
