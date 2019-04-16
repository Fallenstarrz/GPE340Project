using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Missile : Projectile
{
    public GameObject myParticleToCreate;

    /// <summary>
    /// Override function for collisions
    /// Handles what happens when a missile collides with an object
    /// </summary>
    /// <param name="other">collider missile hit</param>
    protected override void OnTriggerEnter(Collider other)
    {
        Collider[] hitColliders = Physics.OverlapSphere(tf.position, weaponThatShot.explosionRadius);
        createParticles(myParticleToCreate);
        foreach (Collider hit in hitColliders)
        {
            // if actor hit has Stats make them take damage
            if (hit.gameObject.GetComponent<Stats>() != null)
            {
                hit.gameObject.GetComponent<Stats>().takeDamage(weaponThatShot.damage);
            }
            // TODO: Curently causes an issue due to root motion!
            // The root motion being enabled won't allow physics to take over the movement, so the explosion force doesn't do anything
            // if actor hit has a rigidbody apply explosion force
            if (hit.gameObject.GetComponent<Rigidbody>() != null)
            {
                hit.gameObject.GetComponent<Rigidbody>().AddExplosionForce(weaponThatShot.explosionForce, tf.position, weaponThatShot.explosionRadius, weaponThatShot.explosionVertivalForce, ForceMode.Impulse);
            }
        }
        base.OnTriggerEnter(other);
    }

    protected override void createParticles(GameObject particleToSpawn)
    {
        Instantiate(particleToSpawn, tf.position, tf.rotation);
        base.createParticles(particleToSpawn);
    }
}
