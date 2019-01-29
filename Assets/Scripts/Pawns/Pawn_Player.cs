using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn_Player : Pawn
{
	// Use this for initialization
	protected override void Start ()
    {
        base.Start();
	}
	
	// Update is called once per frame
	void Update ()
    {
        checkFalling();
	}

    public override void move(Vector3 moveVector)
    {
        anim.SetFloat("Vertical", moveVector.z);
        anim.SetFloat("Horizontal", moveVector.x);
        anim.SetFloat("Speed", makeSpeed(moveVector));
        base.move(moveVector);
    }

    public override void rotate(Vector3 rotationTarget)
    {
        // Draw a plane starting at the player's position using the up vector as the 
        Plane thePlane = new Plane(Vector3.up, tf.position);
        float distance;
        Ray theRay = Camera.main.ScreenPointToRay(rotationTarget);
        thePlane.Raycast(theRay, out distance);
        // Targetpoint is the vector3 at the distance on the ray
        Vector3 targetPoint = theRay.GetPoint(distance);
        tf.LookAt(targetPoint);

        base.rotate(rotationTarget);
    }

    public override void sprint(bool sprinting)
    {
        anim.SetBool("isSprinting", sprinting);
        base.sprint(sprinting);
    }

    public override void crouch(bool crouching)
    {
        anim.SetBool("isCrouching", crouching);
        base.crouch(crouching);
    }

    public float makeSpeed(Vector3 vectorToUse)
    {
        Vector2 newVector = new Vector2(vectorToUse.x, vectorToUse.z);
        return newVector.magnitude;
    }

    public override void checkFalling()
    {
        base.checkFalling();
    }
}
