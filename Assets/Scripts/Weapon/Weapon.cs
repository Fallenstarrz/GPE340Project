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

    [Header("Shoot Cooldown")]
    [SerializeField]
    protected float shootCooldownCurrent;
    [SerializeField]
    protected float shootCooldownMax;

    [Header("Bullet Info")]
    public float damage;
    protected float bulletSpread;
    public float bulletSpeed;
    public bool stopOnCollision;
    public float explosionRadius;
    public float explosionForce;
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
    /// <summary>
    /// Reduce the cooldown of shoot by the time since the last frame
    /// </summary>
	void Update ()
    {
        if (shootCooldownCurrent >= 0)
        {
            shootCooldownCurrent -= Time.deltaTime;
        }
	}
    /// <summary>
    /// Parent shoot function
    /// spawn proectile and set a reference to it
    /// now set the weapon that fired that projectile, so we can use data from children classes
    /// </summary>
    /// <param name="stats"></param>
    public virtual void Shoot(Stats stats)
    {
        Projectile projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(Random.onUnitSphere * bulletSpread));
        projectile.weaponThatShot = this;
    }

    /// <summary>
    /// Add ammo function, used for pickups when we already possess the weapon, or are picking it up for the first time
    /// </summary>
    /// <param name="stats"></param>
    public virtual void addAmmo(Stats stats)
    {

    }
}
