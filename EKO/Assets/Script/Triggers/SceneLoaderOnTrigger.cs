using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderOnTrigger : MonoBehaviour
{
    [Tooltip("The name of the scene to load when the collider is entered.")]
    public string sceneToLoad;
    [SerializeField] Animator transitionAnimator;
    [SerializeField] GameObject transitionCanvas;

    [SerializeField] bool myDontFadeIn;

    [SerializeField] LoadScene myloadScene;

    private void Awake()
    {
        transitionAnimator = transitionCanvas.GetComponentInChildren<Animator>();
        if (myDontFadeIn)
        {
            transitionAnimator.SetBool("startFade", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the collider has the tag "Player"
        if (other.CompareTag("Player"))
        {
            LoadScene();
            
        }
    }

    public void RestartScene()
    {
        LoadCurrentScene();
    }

    void LoadScene()
    {
        if (Application.CanStreamedLevelBeLoaded(sceneToLoad))
        {
            transitionAnimator.SetTrigger("Fade");
            myloadScene.SetSceneToLoad(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Scene " + sceneToLoad + " cannot be loaded. Please check the scene name and ensure it is added to the Build Settings.");
        }

    }

    void LoadCurrentScene()
    {
        if (Application.CanStreamedLevelBeLoaded(SceneManager.GetActiveScene().name))
        {
            transitionAnimator.SetTrigger("Fade");
            myloadScene.SetSceneToLoad(SceneManager.GetActiveScene().name);
        }
        else
        {
            Debug.LogWarning("Scene " + SceneManager.GetActiveScene().name + " cannot be loaded. Please check the scene name and ensure it is added to the Build Settings.");
        }

    }
}
