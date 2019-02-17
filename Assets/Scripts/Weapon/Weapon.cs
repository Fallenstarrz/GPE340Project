using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Transform rightHandPoint;
    public Transform leftHandPoint;
    public Transform firePoint;
    public int ammoToAdd;

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
