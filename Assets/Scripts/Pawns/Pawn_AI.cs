using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn_AI : Pawn
{
    // Stub class, functionality not yet implemented
    // all functions currently exist in parent

    public override void move(Vector3 moveVector)
    {
        base.move(moveVector);
    }
    public override void rotateTowards(Vector3 rotationTarget)
    {
        // Add functionality here
        base.rotateTowards(rotationTarget);
    }
    public override void sprint(bool sprinting)
    {
        base.sprint(sprinting);
    }
    public override void crouch(bool crouching)
    {
        base.crouch(crouching);
    }
    public override void checkFalling()
    {
        base.checkFalling();
    }
    public override void equipWeapon(Weapon weapon)
    {
        base.equipWeapon(weapon);
    }
    public override void unequipWeapon(Weapon weapon)
    {
        base.unequipWeapon(weapon);
    }
}
