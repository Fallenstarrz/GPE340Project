using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Missile : Projectile
{
    /// <summary>
    /// Override function for collisions
    /// Handles what happens when a missile collides with an object
    /// </summary>
    /// <param name="collision">collider missile hit</param>
    protected override void OnCollisionEnter(Collision collision)
    {
        Collider[] hitColliders = Physics.OverlapSphere(tf.position, weaponThatShot.explosionRadius);
        foreach (Collider hit in hitColliders)
        {
            if (hit.gameObject.GetComponent<Stats>() != null)
            {
                hit.gameObject.GetComponent<Stats>().takeDamage(weaponThatShot.damage);
                // The explosion force doesn't work as expected
                hit.gameObject.GetComponent<Rigidbody>().AddExplosionForce(weaponThatShot.explosionForce, tf.position, weaponThatShot.explosionRadius, 1f, ForceMode.Impulse);
            }
        }
        base.OnCollisionEnter(collision);
    }
}
