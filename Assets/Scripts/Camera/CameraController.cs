using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    public Transform targetTF;
    private Transform tf;
    [Range(0.0f, 1.0f)]
    public float smoothRate;

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

    void moveCamera()
    {
        Vector3 newPosition = targetTF.position + offset;
        tf.position = Vector3.Lerp(tf.position, newPosition, smoothRate);
    }
}
