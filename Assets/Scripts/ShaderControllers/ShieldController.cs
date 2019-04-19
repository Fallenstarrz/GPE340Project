using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [SerializeField]
    private SkinnedMeshRenderer surfaceMesh;
    [SerializeField]
    private Material[] shieldMaterial;
    private float fillAmount;
    [SerializeField]
    private float shieldFillRate;
    public bool isGrowShieldRunning;

    // Use this for initialization
    void Start()
    {
        surfaceMesh.materials = shieldMaterial;
        fillAmount = -1;
        shieldMaterial[0].SetFloat("_StepValue", fillAmount);
        StartCoroutine("growShield");
    }

    /// <summary>
    /// Function to call coroutine from other functions
    /// </summary>
    public void raiseShield()
    {
        StartCoroutine("growShield");
    }

    /// <summary>
    /// Set shield fill amount to -1 (completely invisible)
    /// </summary>
    public void disableShield()
    {
        fillAmount = -1;
        shieldMaterial[0].SetFloat("_StepValue", fillAmount);
        if (isGrowShieldRunning)
        {
            StopCoroutine("growShield"); 
        }
    }

    /// <summary>
    /// Coroutine
    /// Increase shield shader property for fillAmount, so the shield crawls up the body of the user
    /// </summary>
    /// <returns></returns>
    IEnumerator growShield()
    {
        isGrowShieldRunning = true;
        if (GameManager.instance.isPaused == true)
        {
            yield return null;
        }
        while (shieldMaterial[0].GetFloat("_StepValue") < 1)
        {
            fillAmount += Time.deltaTime * shieldFillRate;
            shieldMaterial[0].SetFloat("_StepValue", fillAmount);
            yield return null;
        }
        isGrowShieldRunning = false;
    }
}
