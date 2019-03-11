using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorSpawner_Player : ActorSpawner
{
    protected override void spawnActor()
    {
        if (GameManager.instance.spawnedPlayer == null)
        {
            base.spawnActor();
        }
    }

    protected override void OnDrawGizmos()
    {
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.color = Color.Lerp(Color.green, Color.clear, 0.5f);
        Gizmos.DrawCube(Vector3.up * scale.y / 2f, scale);
        base.OnDrawGizmos();
    }
}