using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectSwitcher : MonoBehaviour
{
    public List<GameObject> UILevelDisplay;
    private int index = 0;

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

    private void hideCurrent()
    {
        UILevelDisplay[index].SetActive(false);
    }

    private void showNext()
    {
        UILevelDisplay[index].SetActive(true);
    }
}
