using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn_Player : Pawn
{
    protected override void Start()
    {
        GameManager.instance.spawnedPlayer = this.gameObject;
        base.Start();
    }
    /// <summary>
    /// Pawn child class.
    /// Move towards the target. For the player the target is their movement input.
    /// It will use root motion to propel the character.
    /// </summary>
    /// <param name="moveVector"></param>
    public override void move(Vector3 moveVector)
    {
        base.move(moveVector);
    }

    /// <summary>
    /// Pawn child class.
    /// Rotate towards the rotation target. For the player this is their mouse position.
    /// It will snap the rotation to the mouse position.
    /// </summary>
    /// <param name="rotationTarget">target to rotate towards</param>
    public override void rotateTowards(Vector3 rotationTarget)
    {
        // Draw a plane starting at the player's position using the up vector as the 
        Plane thePlane = new Plane(Vector3.up, tf.position);
        float distance;
        Ray theRay = Camera.main.ScreenPointToRay(rotationTarget);
        thePlane.Raycast(theRay, out distance);
        // Targetpoint is the vector3 at the distance on the ray
        Vector3 targetPoint = theRay.GetPoint(distance);
        //tf.LookAt(targetPoint);

        base.rotateTowards(targetPoint);
    }

    /// <summary>
    /// Pawn child class.
    /// Get/Set if the player is currently sprinting.
    /// </summary>
    /// <param name="sprinting">Boolean to check if the player is sprinting</param>
    public override void sprint(bool sprinting)
    {
        if (sprinting == true)
        {
            if (stats.staminaCurrent >= 0)
            {
                stats.staminaCurrent -= stats.staminaDrainSprinting * Time.deltaTime;
                stats.staminaRegenDelayCurrent = stats.staminaRegenDelayMax;
                anim.SetBool("isSprinting", sprinting);
            }
            else
            {
                anim.SetBool("isSprinting", false);
            }
        }
        else
        {
            anim.SetBool("isSprinting", false);
        }
        base.sprint(sprinting);
    }

    /// <summary>
    /// Pawn child class.
    /// Get/Set if the player is currently crouching.
    /// </summary>
    /// <param name="crouching">boolean to check if the player is crouching</param>
    public override void crouch(bool crouching)
    {
        base.crouch(crouching);
    }

    /// <summary>
    /// Pawn child class.
    /// Checks if player is falling
    /// </summary>
    public override void checkFalling()
    {
        base.checkFalling();
    }

    /// <summary>
    /// Equip a weapon
    /// </summary>
    /// <param name="weapon">Weapon to equip</param>
    public override void equipWeapon(Weapon weapon)
    {
        base.equipWeapon(weapon);
    }

    /// <summary>
    /// Remove currently equipped weapon
    /// </summary>
    /// <param name="weapon">Weapon to remove</param>
    public override void unequipWeapon(Weapon weapon)
    {
        base.unequipWeapon(weapon);
    }

    public override void die()
    {
        base.die();
    }
}
