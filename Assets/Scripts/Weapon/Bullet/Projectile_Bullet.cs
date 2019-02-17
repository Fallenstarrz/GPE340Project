using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Bullet : Projectile
{
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Stats>() != null)
        {
            collision.gameObject.GetComponent<Stats>().takeDamage(weaponThatShot.damage);
            if (weaponThatShot.stopOnCollision == true)
            {
                base.OnCollisionEnter(collision);
            }
        }
        else
        {
            base.OnCollisionEnter(collision);
        }
    }
}
