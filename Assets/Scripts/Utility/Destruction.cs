using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    [SerializeField]
    private float timeBeforeDestruction = 3.0f;
    
    // Destroy after a short delay
    void Start()
    {
        Destroy(this.gameObject, timeBeforeDestruction);
    }
}
