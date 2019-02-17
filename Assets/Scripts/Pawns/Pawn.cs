using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public Transform tf;
    [HideInInspector]
    public Stats stats;

    [Header("Sockets")]
    public Transform weaponSocket;
    [HideInInspector]
    public Transform rightHandPoint;
    [HideInInspector]
    public Transform leftHandPoint;

    [Header ("Falling Settings")]
    [Range (0f,10f)]
    [SerializeField]
    [Tooltip("Distance at which to check for ground")]
    protected float checkGroundDistance;
    protected CapsuleCollider charCollider;

    [Header("Crouch Settings")]
    [Range(0f, 10f)]
    [SerializeField]
    [Tooltip("Distance to check for objects above head")]
    protected float checkRoofDistance;

    [Header("Collider Variables")]
    [SerializeField]
    [Tooltip("Height of collider during crouching")]
    protected float colliderHeightCrouching;
    [SerializeField]
    [Tooltip("Height of collider during standing")]
    protected float colliderHeightStanding;
    [SerializeField]
    [Tooltip("Center of collider during crouching")]
    protected Vector3 colliderCenterCrouching;
    [SerializeField]
    [Tooltip("Center of collider during standing")]
    protected Vector3 colliderCenterStanding;
    [SerializeField]
    [Range(0f,1f)]
    [Tooltip("Changes how fast the collider resizes when transitioning between crouching and standing")]
    protected float colliderChangeRate;

    // Use this for initialization
    protected void Start ()
    {
        anim = GetComponent<Animator>();
        tf = GetComponent<Transform>();
        charCollider = GetComponent<CapsuleCollider>();
        stats = GetComponent<Stats>();

        equipWeapon(stats.inventory[0]);
	}

    protected void Update()
    {
        checkFalling();
    }

    /// <summary>
    /// Pawn object parent class.
    /// Handles the movement of the pawn
    /// </summary>
    /// <param name="moveVector">movement direction from current position</param>
    public virtual void move(Vector3 moveVector)
    {

    }

    /// <summary>
    /// Pawn object parent class.
    /// Handles the rotation of the pawn
    /// </summary>
    /// <param name="rotationTarget">Target to rotate towards</param>
    public virtual void rotateTowards(Vector3 rotationTarget)
    {

    }

    /// <summary>
    /// Pawn object parent class
    /// Handles sprinting by setting the isSprinting parameter in mechanic
    /// </summary>
    /// <param name="sprinting">Boolean value used to determine if the player is currently sprinting</param>
    public virtual void sprint(bool sprinting)
    {

    }

    /// <summary>
    /// Pawn object parent class
    /// Play the crouching animation and resize the collider to the new crouching height.
    /// If the player is no longer crouching resize the collider to the new standing height
    /// </summary>
    /// <param name="crouching">Boolean value used to determine if the player is currently crouching.</param>
    public virtual void crouch(bool crouching)
    {
        Vector3 colliderCenterCurrent = charCollider.center;
        float colliderHeightCurrent = charCollider.height;
        if (crouching == true)
        {
            charCollider.height = Mathf.Lerp(colliderHeightCurrent, colliderHeightCrouching, colliderChangeRate);
            charCollider.center = Vector3.Lerp(colliderCenterCurrent, colliderCenterCrouching, colliderChangeRate);
            anim.SetBool("isCrouching", crouching);
        }
        else
        {
            RaycastHit hit;
            if (Physics.SphereCast(tf.position - new Vector3(0, -.5f, 0), charCollider.radius, tf.up, out hit, checkRoofDistance))
            {

            }
            else
            {
                charCollider.height = Mathf.Lerp(colliderHeightCurrent, colliderHeightStanding, colliderChangeRate);
                charCollider.center = Vector3.Lerp(colliderCenterCurrent, colliderCenterStanding, colliderChangeRate);
                anim.SetBool("isCrouching", crouching);
            }
        }
        Debug.DrawRay(tf.position-new Vector3(0,-.5f,0), tf.up, Color.red);
    }

    /// <summary>
    /// Pawn object parent class.
    /// Check if the character is currently falling by using a raycast downwards. If the raycast hits something
    /// within the distanceToGround variable's range then we aren't falling. Otherwise play falling animations.
    /// </summary>
    public virtual void checkFalling()
    {
        RaycastHit hit;
        float distanceToGround;
        if (Physics.SphereCast(tf.position - new Vector3(0,-.5f,0), charCollider.radius ,-tf.up, out hit))
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

    /// <summary>
    /// Equip the parameter
    /// if we have a weapon already equip, unequip it
    /// then set up IK positions for the new weapon
    /// </summary>
    /// <param name="weapon">Weapon to equip</param>
    public virtual void equipWeapon(Weapon weapon)
    {
        if (stats.weaponEquipped != weapon)
        {
            if (stats.weaponEquipped != null)
            {
                unequipWeapon(stats.weaponEquipped);
            }
            stats.weaponEquipped = Instantiate(weapon);

            stats.weaponEquipped.transform.SetParent(weaponSocket);
            stats.weaponEquipped.transform.localPosition = weapon.transform.localPosition;
            stats.weaponEquipped.transform.localRotation = weapon.transform.localRotation;
            stats.weaponEquipped.currentWeaponType = weapon.currentWeaponType;
            setAnimLayer();

            rightHandPoint = stats.weaponEquipped.rightHandPoint;
            leftHandPoint = stats.weaponEquipped.leftHandPoint;

            stats.weaponEquipped.gameObject.layer = gameObject.layer;
        }
    }

    /// <summary>
    /// Destroy pawn gameObject when this function is called
    /// </summary>
    public void die()
    {
        Destroy(gameObject);
        // Add animation for death
        // Add effect for death
        // Add sound for death
        // Trigger Respawn
    }

    /// <summary>
    /// remove currently equipped weapon
    /// then remove the reference to it in stats
    /// </summary>
    /// <param name="weapon"></param>
    public virtual void unequipWeapon(Weapon weapon)
    {
        Destroy(weapon.gameObject);
        stats.weaponEquipped = null;
    }

    /// <summary>
    ///  swap animation layers according to weapon type
    /// </summary>
    void setAnimLayer()
    {
        anim.SetInteger("WeaponLayerIndex", (int)(stats.weaponEquipped.currentWeaponType));
    }

    /// <summary>
    /// Set IK positions
    /// </summary>
    /// <param name="layerIndex"></param>
    private void OnAnimatorIK(int layerIndex)
    {
        if (rightHandPoint == null)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.0f);
        }
        else
        {
            anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandPoint.position);
            anim.SetIKRotation(AvatarIKGoal.RightHand, rightHandPoint.rotation);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
        }
        if (leftHandPoint == null)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.0f);
        }
        else
        {
            anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandPoint.position);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHandPoint.rotation);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);
        }
    }
}
