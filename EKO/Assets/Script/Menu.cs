using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject credits;

    public void PlayGame()
    {
        Debug.Log("Game is Playing");
        SceneManager.LoadScene("Level1");
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
}
