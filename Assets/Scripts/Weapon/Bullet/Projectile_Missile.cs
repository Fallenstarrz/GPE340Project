using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Missile : Projectile
{
    protected override void OnCollisionEnter(Collision collision)
    {
        Collider[] hitColliders = Physics.OverlapSphere(tf.position, weaponThatShot.explosionRadius);
        foreach (Collider hit in hitColliders)
        {
            if (hit.gameObject.GetComponent<Stats>() != null)
            {
                hit.gameObject.GetComponent<Stats>().takeDamage(weaponThatShot.damage);
            }
        }
        base.OnCollisionEnter(collision);
    }
}
