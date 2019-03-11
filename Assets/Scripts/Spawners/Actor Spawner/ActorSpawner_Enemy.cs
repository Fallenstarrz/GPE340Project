using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorSpawner_Enemy : ActorSpawner
{
    /// <summary>
    /// if currently spawned enemies are fewer than max spawnable enemies then spawn an enemy and ++ our currently spawned enemies
    /// </summary>
    protected override void spawnActor()
    {
        if (GameManager.instance.currentEnemiesSpawned <= GameManager.instance.maxEnemiesSpawned)
        {
            GameManager.instance.currentEnemiesSpawned++;
            base.spawnActor();
        }
    }

    /// <summary>
    /// draw gizmos to show spawn points.
    /// These will be red in color in the world
    /// </summary>
    protected override void OnDrawGizmos()
    {
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.color = Color.Lerp(Color.red, Color.clear, 0.5f);
        Gizmos.DrawCube(Vector3.up * scale.y / 2f, scale);
        base.OnDrawGizmos();
    }
}