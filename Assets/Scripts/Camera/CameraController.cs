﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header ("Camera Movement")]
    [Range(0.0f, 1.0f)]
    [SerializeField]
    private float smoothRate;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Transform targetTF;
    private Transform tf;

	// Use this for initialization
	void Start ()
    {
        tf = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        moveCamera();
	}
    /// <summary>
    /// Set camera position to target's position plus an offset and lerp between those two positions.
    /// </summary>
    void moveCamera()
    {
        Vector3 newPosition = targetTF.position + offset;
        tf.position = Vector3.Lerp(tf.position, newPosition, smoothRate);
    }
}
