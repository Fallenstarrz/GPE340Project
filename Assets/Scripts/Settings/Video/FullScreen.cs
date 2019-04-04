using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
    public void setFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
