using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIController : MonoBehaviour
{
    [SerializeField]
    private Pawn_AI pawn;

    [SerializeField]
    private Transform target;

    public float distanceToTargetMin;
    public float distanceToTargetMax;
    private float distanceToTargetActual;

    // States AI can perform
    public enum AIStates
    {
        idle,
        wander,
        chase,
        chaseAndShoot,
        shoot,
        dead
    }
    public AIStates currentState;

	// Use this for initialization
	void Start ()
    {
        acquireTarget();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (target != null)
        {
            distanceToTargetActual = Vector3.Distance(pawn.tf.position, target.position);
        }
        else
        {
            acquireTarget();
        }

        // State manager
        switchStates();
        stateDead();

        // Weapon call functions
        // Still need to come up with a way to manage weapons on AIs
        switchWeapons();

        pawn.canSeeTarget(target);
    }

    // Set AI states
    void switchStates()
    {
        switch (currentState)
        {
            case AIStates.idle:
                stateIdle();
                break;
            case AIStates.wander:
                stateWander();
                break;
            case AIStates.chase:
                stateChase();
                break;
            case AIStates.chaseAndShoot:
                stateChaseAndShoot();
                break;
            case AIStates.shoot:
                stateShoot();
                break;
            case AIStates.dead:
                break;
        }
    }

    // Idle
    void stateIdle()
    {
        if (target != null)
        {
            currentState = AIStates.chase;
        }
        else
        {
            currentState = AIStates.wander;
        }
    }

    // Wander
    //TODO: Need to actually wander around
    void stateWander()
    {
        if (target != null)
        {
            currentState = AIStates.chase;
        }
        else
        {
            // Wander Around Aimlessly
        }
    }

    // chase down the player
    void stateChase()
    {
        if (target == null)
        {
            currentState = AIStates.wander;
        }
        else if (distanceToTargetActual <= distanceToTargetMin && pawn.canSeeTarget(target))
        {
            currentState = AIStates.chaseAndShoot;
        }
        else
        {
            movementHandler(target.position);
        }
    }

    // chase down the player while shooting
    void stateChaseAndShoot()
    {
        if (distanceToTargetActual >= distanceToTargetMin)
        {
            currentState = AIStates.chase;
        }
        else if (distanceToTargetActual <= distanceToTargetMax && pawn.canSeeTarget(target))
        {
            currentState = AIStates.shoot;
        }
        else
        {
            if (target != null)
            {
                movementHandler(target.position); 
            }
            shootHandler();
        }
    }

    // shoot state: Stand still and shoot at player
    void stateShoot()
    {
        if (distanceToTargetActual >= distanceToTargetMax && pawn.canSeeTarget(target))
        {
            currentState = AIStates.chaseAndShoot;
        }
        else
        {
            movementHandler(pawn.tf.position);
            rotationHandler();
            shootHandler();
        }
    }

    // Dead state, no backward transitions
    void stateDead()
    {
        if (pawn.stats.healthCurrent <= 0)
        {
            currentState = AIStates.dead;
        }
    }

    // if there is no target, get one
    void acquireTarget()
    {
        if (target == null)
        {
            if (GameManager.instance.spawnedPlayer != null)
            {
                target = GameManager.instance.spawnedPlayer.gameObject.transform;
            }
        }
    }

    // move the pawn taking targets position as the parameter
    void movementHandler(Vector3 targetPosition)
    {
        if (target != null)
        {
            pawn.move(targetPosition);
        }
    }

    // rotate towards target if a target exists
    void rotationHandler()
    {
        if (target != null)
        {
            pawn.rotateTowards(target.position);
        }
    }

    // TODO: Allow AI to swap to different weapons
    void switchWeapons()
    {
        // add functions here
        // This function is supposed to manage weapon switching
    }

    // shoot weapon that is currently equipped
    void shootHandler()
    {
        pawn.stats.weaponEquipped.Shoot(pawn.stats);
    }
}
