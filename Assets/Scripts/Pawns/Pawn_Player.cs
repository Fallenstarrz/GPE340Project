using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn_Player : Pawn
{
    /// <summary>
    /// Pawn child class.
    /// Move towards the target. For the player the target is their movement input.
    /// It will use root motion to propel the character.
    /// </summary>
    /// <param name="moveVector"></param>
    public override void move(Vector3 moveVector)
    {
        anim.SetFloat("Vertical", moveVector.z);
        anim.SetFloat("Horizontal", moveVector.x);
        anim.SetFloat("Speed", makeSpeed(moveVector));
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
        tf.LookAt(targetPoint);

        base.rotateTowards(rotationTarget);
    }

    /// <summary>
    /// Pawn child class.
    /// Get/Set if the player is currently sprinting.
    /// </summary>
    /// <param name="sprinting">Boolean to check if the player is sprinting</param>
    public override void sprint(bool sprinting)
    {
        anim.SetBool("isSprinting", sprinting);
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
    /// Creates a speed from a passed in vector. The vector will result in a magnitude that can be used as the speed calculation.
    /// </summary>
    /// <param name="vectorToUse">Vector3 to determine the speed</param>
    /// <returns>Returns magnitude of vector to make a speed variable</returns>
    public float makeSpeed(Vector3 vectorToUse)
    {
        Vector2 newVector = new Vector2(vectorToUse.x, vectorToUse.z);
        return newVector.magnitude;
    }

    /// <summary>
    /// Pawn child class.
    /// Checks if player is falling
    /// </summary>
    public override void checkFalling()
    {
        base.checkFalling();
    }
}
