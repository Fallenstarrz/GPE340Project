using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform tf;
    public Vector3 myRotation;

    private void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion newRotation = Quaternion.Euler(myRotation);
        tf.rotation = newRotation;
    }
}
