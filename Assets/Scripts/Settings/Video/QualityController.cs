using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityController : MonoBehaviour
{
    public void setQuality(int qualityLevelIndex)
    {
        QualitySettings.SetQualityLevel(qualityLevelIndex);
    }
}
