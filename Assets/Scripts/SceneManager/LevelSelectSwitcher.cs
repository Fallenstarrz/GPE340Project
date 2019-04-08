using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectSwitcher : MonoBehaviour
{
    public List<GameObject> UILevelDisplay;
    private int index = 0;

    /// <summary>
    /// Increase the level on the UI level switcher
    /// </summary>
    public void incrementDisplayedLevel()
    {
        hideCurrent();
        index++;
        if (index >= UILevelDisplay.Count)
        {
            index = 0;
        }
        showNext();
    }

    /// <summary>
    /// Decrease the level on the UI level switcher
    /// </summary>
    public void decrementDisplayedLevel()
    {
        hideCurrent();
        index--;
        if (index < 0)
        {
            index = UILevelDisplay.Count-1;
        }
        showNext();
    }

    /// <summary>
    /// Toggle off the current visibility of levels
    /// </summary>
    private void hideCurrent()
    {
        UILevelDisplay[index].SetActive(false);
    }

    /// <summary>
    /// Toggle on the visibilitiy of the next level
    /// </summary>
    private void showNext()
    {
        UILevelDisplay[index].SetActive(true);
    }
}
