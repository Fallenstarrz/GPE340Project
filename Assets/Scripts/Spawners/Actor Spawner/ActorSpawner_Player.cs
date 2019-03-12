using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorSpawner_Player : ActorSpawner
{
    /// <summary>
    /// if a player is not currently spawned, then spawn one
    /// </summary>
    protected override void spawnActor()
    {
        if (GameManager.instance.spawnedPlayer == null)
        {
            base.spawnActor();
        }
    }

    /// <summary>
    /// draw gizmos to show spawn points.
    /// These will be green in color in the world
    /// </summary>
    protected override void OnDrawGizmos()
    {
        Color newColor;
        newColor.r = 0;
        newColor.g = 255;
        newColor.b = 0;
        newColor.a = 255;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.color = newColor;
        Gizmos.DrawCube(Vector3.up * scale.y / 2f, scale);
        base.OnDrawGizmos();
    }
}