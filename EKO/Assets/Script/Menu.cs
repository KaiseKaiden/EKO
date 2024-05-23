using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject credits;
    [SerializeField] Animator transitionAnimator;
    [SerializeField] GameObject transitionCanvas;

    private void Start()
    {
        transitionAnimator = GetComponent<Animator>();

    }

 
    public IEnumerator PlayGame()
    {
        transitionCanvas.SetActive(true);
        transitionAnimator.SetTrigger("TriggerBlackFade");
        Debug.Log("Fading in");

        yield return new WaitForSeconds(1);

        Debug.Log("Game is Playing");
        SceneManager.LoadScene("Level1");
        transitionCanvas.SetActive(false);
    }

    public void OpenCredits()
    {
        credits.SetActive(true);    
    }

    public void CloseCredits()
    {
        credits.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Game is Quitting");
        Application.Quit();
    }

    IEnumerator TransitionBlack()
    {
        transitionCanvas.SetActive(true);
        transitionAnimator.SetTrigger("TriggerBlackFade");

        yield return new WaitForSeconds(1);

        transitionCanvas.SetActive(false);
    }
    IEnumerator TransitionWhite()
    {
        transitionCanvas.SetActive(true);
        transitionAnimator.SetTrigger("TriggerWhiteFade");

        yield return new WaitForSeconds(1);

        transitionCanvas.SetActive(false);
    }

}
