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

    void stateChase()
    {
        if (target == null)
        {
            currentState = AIStates.wander;
        }
        else if (distanceToTargetActual <= distanceToTargetMin)
        {
            currentState = AIStates.chaseAndShoot;
        }
        else
        {
            movementHandler(target.position);
        }
    }

    void stateChaseAndShoot()
    {
        if (distanceToTargetActual >= distanceToTargetMin)
        {
            currentState = AIStates.chase;
        }
        else if (distanceToTargetActual <= distanceToTargetMax)
        {
            currentState = AIStates.shoot;
        }
        else
        {
            movementHandler(target.position);
            shootHandler();
        }
    }

    void stateShoot()
    {
        if (distanceToTargetActual >= distanceToTargetMax)
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

    void stateDead()
    {
        if (pawn.stats.healthCurrent <= 0)
        {
            currentState = AIStates.dead;
        }
    }

    void acquireTarget()
    {
        if (target == null)
        {
            // TODO: Temp: Get reference from game manager
            target = FindObjectOfType<Pawn_Player>().transform;
        }
    }

    void movementHandler(Vector3 targetPosition)
    {
        if (target != null)
        {
            pawn.move(targetPosition);
        }
    }

    void rotationHandler()
    {
        if (target != null)
        {
            pawn.rotateTowards(target.position);
        }
    }

    void switchWeapons()
    {
        // add functions here
        // This function is supposed to manage weapon switching
    }

    void shootHandler()
    {
        pawn.stats.weaponEquipped.Shoot(pawn.stats);
    }
}
