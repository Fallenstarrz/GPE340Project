using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
    /// <summary>
    /// Toggle full screen on and off via UI component
    /// </summary>
    /// <param name="isFullScreen">boolean value received by toggle component of UI</param>
    public void setFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
