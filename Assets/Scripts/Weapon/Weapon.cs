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
    public float damage;
    [SerializeField]
    protected float bulletSpread;
    [SerializeField]
    public float bulletSpeed;
    [SerializeField]
    public bool stopOnCollision;
    [SerializeField]
    public float explosionRadius;
    [SerializeField]
    public float projectileLifespan;

    [Header("Bullet to Shoot")]
    public Projectile bulletPrefab;

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
        if (shootCooldownCurrent >= 0)
        {
            shootCooldownCurrent -= Time.deltaTime;
        }
	}

    public virtual void Shoot(Stats stats)
    {
        Projectile projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(Random.onUnitSphere * bulletSpread));
        projectile.weaponThatShot = this;
    }

    public virtual void addAmmo(Stats stats)
    {

    }
}
