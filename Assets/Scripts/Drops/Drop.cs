using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Non-Monobehavior class
/// Used to store information about the drops the AI may drop
/// </summary>
[System.Serializable]
public class Drop
{
    public GameObject itemDrop;
    public float weight;
}
