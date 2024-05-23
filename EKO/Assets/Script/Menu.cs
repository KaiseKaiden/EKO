using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject credits;
    [SerializeField] GameObject creditsButtons;
    [SerializeField] Animator transitionAnimator;
    [SerializeField] GameObject transitionCanvas;


    private void Start()
    {
        transitionAnimator = transitionCanvas.GetComponentInChildren<Animator>();
    }

    public void PlayGame()
    {
        StartCoroutine(Play());
    }
 
    public IEnumerator Play()
    {
        transitionCanvas.SetActive(true);

        transitionAnimator.SetBool("TriggerBlackFade",true);
        Debug.Log("Fading in");

        yield return new WaitForSeconds(0.9f);

        Debug.Log("Game is Playing");
        transitionAnimator.SetBool("TriggerBlackFade", false);
        transitionCanvas.SetActive(false);
        SceneManager.LoadScene("Train1");
      
    }

    public void OpenCredits()
    {
        credits.SetActive(true);  
        creditsButtons.SetActive(true);
    }

    public void CloseCredits()
    {
        credits.SetActive(false);
        creditsButtons.SetActive(false);
    }

    public void QuitGame()
    {
        StartCoroutine(Quit());
    }

    public IEnumerator Quit()
    {
        transitionCanvas.SetActive(true);
        transitionAnimator.SetTrigger("TriggerBlackFade");
        Debug.Log("Game is Quitting");

        yield return new WaitForSeconds(0.9f);

        transitionCanvas.SetActive(false);
        Application.Quit();
    }


    IEnumerator TransitionWhite()
    {
        transitionCanvas.SetActive(true);
        transitionAnimator.SetTrigger("TriggerWhiteFade");

        yield return new WaitForSeconds(0.9f);

        transitionCanvas.SetActive(false);
    }

}
