using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    string mySceneToLoad;

    public void SetSceneToLoad(string aSceneName)
    {
        mySceneToLoad = aSceneName;
    }

    public void Load()
    {
        SceneManager.LoadScene(mySceneToLoad);
    }
}
