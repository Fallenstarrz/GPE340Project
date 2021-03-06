﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Pawn pawn;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPaused == false)
        {
            if (pawn == null)
            {
                if (GameManager.instance.spawnedPlayer != null)
                {
                    pawn = GameManager.instance.spawnedPlayer.GetComponent<Pawn>();
                }
            }
            // Call methods on update
            else if (!pawn.isDead)
            {
                movementHandler();
                rotationHandler();
                sprintHandler();
                crouchHandler();
                switchWeapons();
                shootHandler();
            } 
        }
        pauseHandler();
    }

    /// <summary>
    /// Tell the pawn to move in movement direction while maintaining world forward as pawn's forward.
    /// </summary>
    void movementHandler()
    {
        Vector3 movementVector = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        movementVector = Vector3.ClampMagnitude(movementVector, 1.0f);
        movementVector = pawn.tf.InverseTransformDirection(movementVector);
        pawn.move(movementVector);
    }
    /// <summary>
    /// Rotate the player taking in a mouse position as a parameter.
    /// </summary>
    void rotationHandler()
    {
        // Need some work done here
        pawn.rotateTowards(Input.mousePosition);
    }
    /// <summary>
    /// Tell the pawn to toggle on the movement animations in order to enable sprinting
    /// </summary>
    void sprintHandler()
    {
        if (Input.GetButton("Sprint"))
        {
            pawn.sprint(true);
        }
        else
        {
            pawn.sprint(false);
        }
    }
    /// <summary>
    /// Tell the pawn to toggle on the movement animations on the gnenide,
    /// </summary>
    void crouchHandler()
    {
        if (Input.GetButton("Crouch"))
        {
            pawn.crouch(true);
        }
        else
        {
            pawn.crouch(false);
        }
    }

    /// <summary>
    /// Tell pawn's current weapon to shoot
    /// </summary>
    void shootHandler()
    {
        if (Input.GetButton("Shoot"))
        {
            pawn.stats.weaponEquipped.Shoot(pawn.stats);
        }
    }

    // Tell pawn to switch weapons in Inventory
    void switchWeapons()
    {
        if (Input.GetButtonDown("WeaponSelectScroll"))
        {

        }
        if (Input.GetButtonDown("WeaponSlot1"))
        {
            if (pawn.stats.inventory[0] != null)
            {
                pawn.equipWeapon(pawn.stats.inventory[0]);
            }
            else
            {
                Debug.Log("No weapon that slot");
            }
        }
        if (Input.GetButtonDown("WeaponSlot2"))
        {
            if (pawn.stats.inventory[1] != null)
            {
                pawn.equipWeapon(pawn.stats.inventory[1]);
            }
            else
            {
                Debug.Log("No weapon that slot");
            }
        }
        if (Input.GetButtonDown("WeaponSlot3"))
        {
            if (pawn.stats.inventory[2] != null)
            {
                pawn.equipWeapon(pawn.stats.inventory[2]);
            }
            else
            {
                Debug.Log("No weapon that slot");
            }
        }
        if (Input.GetButtonDown("WeaponSlot4"))
        {
            if (pawn.stats.inventory[3] != null)
            {
                pawn.equipWeapon(pawn.stats.inventory[3]);
            }
            else
            {
                Debug.Log("No weapon that slot");
            }
        }
        if (Input.GetButtonDown("WeaponSlot5"))
        {
            if (pawn.stats.inventory[4] != null)
            {
                pawn.equipWeapon(pawn.stats.inventory[4]);
            }
            else
            {
                Debug.Log("No weapon that slot");
            }
        }
        if (Input.GetButtonDown("UnequipAll"))
        {
            pawn.unequipWeapon(pawn.stats.weaponEquipped);
        }
    }

    /// <summary>
    /// Handle whether the game should be paused or not.
    /// </summary>
    private static void pauseHandler()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.instance.pauseGame();
        }
    }
}
