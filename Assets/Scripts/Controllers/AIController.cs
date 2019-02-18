using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIController : MonoBehaviour
{
    [SerializeField]
    private Pawn pawn;

    private NavMeshAgent agent;

    [SerializeField]
    private Transform target;

    private Vector3 desiredVelocity;

    //Stub class for finite state machine for the AI behavior in the next milestone
	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();

        // TODO: Set target from gameManager when we create game manager, for now we will find object with tag
        // if (gameManager.instance.player != null)
        //{
        //    target = gameManager.instance.player.transform;
        //}
        target = FindObjectOfType<Pawn_Player>().transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        movementHandler();
        rotationHandler();
        switchWeapons();
        shootHandler();
    }

    void movementHandler()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            desiredVelocity = Vector3.MoveTowards(desiredVelocity, agent.desiredVelocity, agent.acceleration * Time.deltaTime);
            Vector3 input = transform.InverseTransformDirection(desiredVelocity);
            pawn.move(input);
        }
    }

    void rotationHandler()
    {

    }

    void switchWeapons()
    {

    }

    void shootHandler()
    {
        //pawn.stats.weaponEquipped.Shoot(pawn.stats);
    }

    private void OnAnimatorMove()
    {
        agent.velocity = pawn.anim.velocity;
    }
}
