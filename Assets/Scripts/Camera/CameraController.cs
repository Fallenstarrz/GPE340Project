using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header ("Camera Movement")]
    [Range(0.0f, 1.0f)]
    [SerializeField]
    [Tooltip("Rate at which the camera moves towards desired position")]
    private float smoothRate;
    [SerializeField]
    [Tooltip("Position away from the target that the camera will try stay at")]
    private Vector3 offset;
    [SerializeField]
    [Tooltip("Target the camera will follow")]
    private Transform target;
    private Transform tf;

	// Use this for initialization
	void Start ()
    {
        tf = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager.instance.isPaused == false)
        {
            moveCamera();
            if (target == null)
            {
                if (GameManager.instance.spawnedPlayer != null)
                {
                    target = GameManager.instance.spawnedPlayer.gameObject.transform;
                }
            } 
        }
	}
    /// <summary>
    /// Set camera position to target's position plus an offset and lerp between those two positions.
    /// </summary>
    void moveCamera()
    {
        if (target != null)
        {
            Vector3 newPosition = target.position + offset;
            tf.position = Vector3.Lerp(tf.position, newPosition, smoothRate);
        }
    }
}
