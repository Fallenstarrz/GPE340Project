using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityController : MonoBehaviour
{
    /// <summary>
    /// Quality dropdown component controls this item
    /// </summary>
    /// <param name="qualityLevelIndex">index in dropdown list</param>
    public void setQuality(int qualityLevelIndex)
    {
        QualitySettings.SetQualityLevel(qualityLevelIndex);
    }
}
