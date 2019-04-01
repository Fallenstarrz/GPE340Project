using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Pawn_AI : Pawn
{
    private NavMeshAgent agent;

    private Vector3 desiredVelocity;

    private DropController dropController;
    public int numItemsToDrop;

    [SerializeField]
    [Range(0,360)]
    private float fieldOfView;

    // Handle this!
    protected override void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        dropController = GetComponent<DropController>();
        base.Start();
    }

    /// <summary>
    /// Move pawn
    /// </summary>
    /// <param name="moveVector">where to move to</param>
    public override void move(Vector3 moveVector)
    {
        agent.SetDestination(moveVector);
        desiredVelocity = Vector3.MoveTowards(desiredVelocity, agent.desiredVelocity, agent.acceleration * Time.deltaTime);
        Vector3 input = transform.InverseTransformDirection(desiredVelocity);
        base.move(input);
    }
    /// <summary>
    /// rotate pawn
    /// </summary>
    /// <param name="rotationTarget">what to rotate towards</param>
    public override void rotateTowards(Vector3 rotationTarget)
    {
        base.rotateTowards(rotationTarget);
    }
    /// <summary>
    /// sprint
    /// </summary>
    /// <param name="sprinting">should character be sprinting</param>
    public override void sprint(bool sprinting)
    {
        base.sprint(sprinting);
    }
    /// <summary>
    /// crouch
    /// </summary>
    /// <param name="crouching">should character be crouching</param>
    public override void crouch(bool crouching)
    {
        base.crouch(crouching);
    }
    /// <summary>
    /// check if we are falling
    /// </summary>
    public override void checkFalling()
    {
        base.checkFalling();
    }
    /// <summary>
    ///  equip a weapon
    /// </summary>
    /// <param name="weapon"></param>
    public override void equipWeapon(Weapon weapon)
    {
        base.equipWeapon(weapon);
    }
    /// <summary>
    /// Do nothing override function
    /// </summary>
    public override void manageInventory()
    {
        // Do nothing
        base.manageInventory();
    }
    /// <summary>
    /// unequip a weapon
    /// </summary>
    /// <param name="weapon"></param>
    public override void unequipWeapon(Weapon weapon)
    {
        base.unequipWeapon(weapon);
    }
    /// <summary>
    /// Can see target
    /// If target is in field of view, and nothing is between the target and this pawn
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
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
    /// <summary>
    /// if our animator isn't disabled then allow root motion to propel our character
    /// </summary>
    private void OnAnimatorMove()
    {
        if (anim != null && agent != null)
        {
            agent.velocity = anim.velocity;  
        }
    }

    /// <summary>
    /// when we die, tell GM to remove 1 from currentEnemiesSpawned
    /// </summary>
    public override void die()
    {
        GameManager.instance.currentEnemiesSpawned--;
        dropItem();
        dropWeapon();
        base.die();
    }

    private void dropItem()
    {
        int randNum = Random.Range(1, numItemsToDrop);
        for (int i = 0; i < randNum; i++)
        {
            GameObject itemToSpawn = dropController.GetRandomItem();
            if (itemToSpawn != null)
            {
                GameObject item = Instantiate(itemToSpawn, tf.position, tf.rotation);
                addForceInRandomDirection(item);
            }
        }
    }

    private void dropWeapon()
    {
        GameObject weaponDrop = Instantiate(dropController.weapon.itemDrop, tf.position, tf.rotation);
        addForceInRandomDirection(weaponDrop);
    }

    private void addForceInRandomDirection(GameObject itemToPropel)
    {
        // We left off here!
    }
}
