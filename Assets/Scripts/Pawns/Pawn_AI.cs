using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Pawn_AI : Pawn
{
    private NavMeshAgent agent;

    private Vector3 desiredVelocity;

    [SerializeField]
    [Range(0,360)]
    private float fieldOfView;

    // Handle this!
    protected override void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        base.Start();
    }

    public override void move(Vector3 moveVector)
    {
        agent.SetDestination(moveVector);
        desiredVelocity = Vector3.MoveTowards(desiredVelocity, agent.desiredVelocity, agent.acceleration * Time.deltaTime);
        Vector3 input = transform.InverseTransformDirection(desiredVelocity);
        base.move(input);
    }
    public override void rotateTowards(Vector3 rotationTarget)
    {
        base.rotateTowards(rotationTarget);
    }
    public override void sprint(bool sprinting)
    {
        base.sprint(sprinting);
    }
    public override void crouch(bool crouching)
    {
        base.crouch(crouching);
    }
    public override void checkFalling()
    {
        base.checkFalling();
    }
    public override void equipWeapon(Weapon weapon)
    {
        base.equipWeapon(weapon);
    }
    public override void unequipWeapon(Weapon weapon)
    {
        base.unequipWeapon(weapon);
    }
    public bool canSeeTarget(Transform target)
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, tf.position.y, target.position.z);
            Vector3 vectorToTarget = (targetPosition - tf.position);
            float angle = Vector3.Angle(vectorToTarget, tf.forward);

            if (angle >= fieldOfView)
            {
                return false;
            }

            RaycastHit hitInfo;
            Physics.Raycast(tf.position, vectorToTarget, out hitInfo);
            if (hitInfo.collider == null)
            {
                return false;
            }

            Collider targetCollider = target.GetComponent<Collider>();
            if (targetCollider != hitInfo.collider)
            {
                return false;
            }

            return true; 
        }
        else
        {
            return false;
        }
    }
    private void OnAnimatorMove()
    {
        if (anim != null)
        {
            agent.velocity = anim.velocity;  
        }
    }

    public override void die()
    {
        GameManager.instance.currentEnemiesSpawned--;
        base.die();
    }
}
