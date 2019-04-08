using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    /// <summary>
    /// Switch scene to new scene
    /// New scene is a string that is the name of the scene to load
    /// </summary>
    /// <param name="sceneToLoad">Scene to load as a string</param>
    public void switchScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
