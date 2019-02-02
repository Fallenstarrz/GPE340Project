using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public Transform tf;
    [Header ("Falling Settings")]
    [Range (1f,10f)]
    [SerializeField]
    protected float checkGroundDistance;

    // Use this for initialization
    protected virtual void Start ()
    {
        anim = GetComponent<Animator>();
        tf = GetComponent<Transform>();
	}

    public virtual void move(Vector3 moveVector)
    {

    }

    public virtual void rotate(Vector3 rotationTarget)
    {

    }

    public virtual void sprint(bool sprinting)
    {

    }

    public virtual void crouch(bool crouching)
    {

    }

    public virtual void checkFalling()
    {
        RaycastHit hit;
        float distanceToGround;
        if (Physics.Raycast(tf.position, -tf.up, out hit))
        {
            distanceToGround = hit.distance;
            anim.SetFloat("distanceToGround", distanceToGround);
            if (hit.distance >= checkGroundDistance)
            {
                anim.SetBool("isGrounded", false);
            }
            else
            {
                anim.SetBool("isGrounded", true);
            }
        }
    }
}
