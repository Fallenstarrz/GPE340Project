using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Bullet : Projectile
{
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
            if (weaponThatShot.stopOnCollision == true)
            {
                base.OnTriggerEnter(other);
            }
        }
        else
        {
            base.OnTriggerEnter(other);
        }
    }
}
