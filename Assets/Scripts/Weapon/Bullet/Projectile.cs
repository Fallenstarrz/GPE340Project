using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Weapon weaponThatShot;

    protected Rigidbody rb;

    protected Transform tf;
    // Ask gun for information about firing
    // Missile and bullet have different collision effects
    // Pawn needs a take damage and die function
    // Then UI for guns
    // Then stamina drain
    // Wolr space ui for ai would be a nice touch as well

	// Use this for initialization
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

    void propelBullet()
    {
        rb.AddRelativeForce(Vector3.right * weaponThatShot.bulletSpeed, ForceMode.VelocityChange);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
