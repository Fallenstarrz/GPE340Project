using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn_Player : Pawn
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public override void move(float forwardMovement, float sidewaysMovement)
    {
        anim.SetFloat("Vertical", forwardMovement);
        anim.SetFloat("Horizontal", sidewaysMovement);

        base.move(forwardMovement, sidewaysMovement);
    }
}
