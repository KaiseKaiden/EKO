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


    private void Awake()
    {
        transitionAnimator = transitionCanvas.GetComponentInChildren<Animator>();
        StartCoroutine(TransitionWhite());
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the collider has the tag "Player"
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadScene());
            
        }
    }

    IEnumerator LoadScene()
    {
        if (Application.CanStreamedLevelBeLoaded(sceneToLoad))
        {
            transitionCanvas.SetActive(true);
            transitionAnimator.SetBool("TriggerBlackFade", true);

            yield return new WaitForSeconds(0.9f);

            transitionAnimator.SetBool("TriggerBlackFade", false);
            SceneManager.LoadScene(sceneToLoad);
            transitionCanvas.SetActive(false);
        }

        else
        {
            Debug.LogWarning("Scene " + sceneToLoad + " cannot be loaded. Please check the scene name and ensure it is added to the Build Settings.");
        }

    }

    IEnumerator TransitionWhite()
    {
        transitionCanvas.SetActive(true);
        transitionAnimator.SetBool("TriggerWhiteFade",true);

        yield return new WaitForSeconds(0.9f);

        transitionAnimator.SetBool("TriggerWhiteFade", false);
        transitionCanvas.SetActive(false);
    }

}
