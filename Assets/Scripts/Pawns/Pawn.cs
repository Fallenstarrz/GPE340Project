using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public Transform tf;

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
}
