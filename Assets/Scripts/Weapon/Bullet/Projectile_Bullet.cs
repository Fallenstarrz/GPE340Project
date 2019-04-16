using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Bullet : Projectile
{
    public GameObject shieldHitParticle;
    public GameObject lifeHitParticle;
    public GameObject wallHitParticle;
    /// <summary>
    /// check to see if the collidion that has occured is with an object that has stats
    /// if it does deal damage to that object
    /// check if we want to continue after collision, for sniper rifles, rail guns etc...
    /// Current functionality results in a ricochet, to make into a through shot just change bullets collider to a trigger and the projectile function for collision enter to trigger enter
    /// </summary>
    /// <param name="collision"></param>
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Stats>() != null)
        {
            other.gameObject.GetComponent<Stats>().takeDamage(weaponThatShot.damage);
            if (other.gameObject.GetComponent<Stats>().shieldActive == true)
            {
                createParticles(shieldHitParticle);
            }
            else
            {
                createParticles(lifeHitParticle);
            }
            if (weaponThatShot.stopOnCollision == true)
            {
                base.OnTriggerEnter(other);
            }
        }
        else
        {
            createParticles(wallHitParticle);
            base.OnTriggerEnter(other);
        }
    }

    protected override void createParticles(GameObject particleToSpawn)
    {
        GameObject myParticle = Instantiate(particleToSpawn, tf.position, tf.rotation);
        base.createParticles(particleToSpawn);
    }
}
