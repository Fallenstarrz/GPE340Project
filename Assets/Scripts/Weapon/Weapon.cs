using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [Header("IK Information")]
    public Transform rightHandPoint;
    public Transform leftHandPoint;

    [Header("Ammo Information")]
    [SerializeField]
    protected int ammoToAdd;

    [Header("Weapon Stats")]
    [SerializeField]
    protected Transform firePoint;
    [SerializeField]
    protected float shootCooldownCurrent;
    [SerializeField]
    protected float shootCooldownMax;
    [SerializeField]
    protected float damage;
    [SerializeField]
    protected float bulletSpread;

    [Header("Bullet to Shoot")]
    public GameObject bulletPrefab;

    public enum weaponType
    {
        none,
        pistol,
        assaultRifle,
        machineGun,
        sniperRifle,
        rocketLauncher
    }
    public weaponType currentWeaponType;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public virtual void Shoot()
    {

    }

    public virtual void addAmmo(Stats stats)
    {

    }
}
