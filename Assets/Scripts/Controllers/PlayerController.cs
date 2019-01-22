using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Pawn pawn;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        movementHandler();
        rotationHandler();
        sprintHandler();
        crouchHandler();
	}

    void movementHandler()
    {
        Vector3 movementVector = new Vector3(Input.GetAxis("Horizontal"),0.0f, Input.GetAxis("Vertical"));
        movementVector = Vector3.ClampMagnitude(movementVector, 1.0f);
        movementVector = pawn.tf.InverseTransformDirection(movementVector);

        pawn.move(movementVector);
    }

    void rotationHandler()
    {
        // Need some work done here
        pawn.rotate(Input.mousePosition);
    }

    void sprintHandler()
    {
        if (Input.GetButton("Sprint"))
        {
            pawn.sprint(true);
        }
        else
        {
            pawn.sprint(false);
        }
    }

    void crouchHandler()
    {
        if (Input.GetButton("Crouch"))
        {
            pawn.crouch(true);
        }
        else
        {
            pawn.crouch(false);
        }
    }
}
