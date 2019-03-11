using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ragdoll : MonoBehaviour
{
    private Pawn pawn;
    private AIController controller;
    private List<Collider> subColliders;
    private List<Rigidbody> subRigidbodies;
    private Collider mainCollider;
    private Rigidbody mainRigidbody;
    private Animator mainAnimator;
    private NavMeshAgent mainAgent;

    // Use this for initialization
    void Start()
    {
        if (GetComponent<AIController>() != null)
        {
            controller = GetComponent<AIController>();
        }
        if (GetComponent<NavMeshAgent>() != null)
        {
            mainAgent = GetComponent<NavMeshAgent>();
        }

        pawn = GetComponent<Pawn>();
        mainCollider = GetComponent<Collider>();
        mainRigidbody = GetComponent<Rigidbody>();
        mainAnimator = GetComponent<Animator>();
        subColliders = new List<Collider>(GetComponentsInChildren<Collider>());
        subRigidbodies = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>());

        deactivateRagdoll();
    }

    public void deactivateRagdoll()
    {
        foreach (Collider collider in subColliders)
        {
            collider.enabled = false;
        }
        foreach (Rigidbody rb in subRigidbodies)
        {
            rb.isKinematic = true;
        }
        mainCollider.enabled = true;
        mainRigidbody.isKinematic = false;
        mainAnimator.enabled = true;
        pawn.enabled = true;
        if (mainAgent != null)
        {
            mainAgent.enabled = true;
        }
        if (controller != null)
        {
            controller.enabled = true;
        }
    }

    public void activateRagdoll()
    {
        foreach (Collider collider in subColliders)
        {
            if (collider != null)
            {
                collider.enabled = true; 
            }
        }
        foreach (Rigidbody rb in subRigidbodies)
        {
            rb.isKinematic = false;
        }
        mainCollider.enabled = false;
        mainRigidbody.isKinematic = true;
        mainAnimator.enabled = false;
        pawn.enabled = false;
        if (mainAgent != null)
        {
            mainAgent.enabled = false;
        }
        if (controller != null)
        {
            controller.enabled = false;
        }
        if (pawn.stats.weaponEquipped != null)
        {
            pawn.stats.weaponEquipped.gameObject.AddComponent<Rigidbody>();
            pawn.stats.weaponEquipped.GetComponent<Collider>().isTrigger = false;
        }
    }
}
