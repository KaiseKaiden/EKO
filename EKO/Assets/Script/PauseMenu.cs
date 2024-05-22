using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameIsPaused)
            {
                Pause();
            }
            else 
            {
                Resume();   
            }
            
            
        }
        
    }

    public void Menu()
    {
        Debug.Log("You Are In Menu");
        SceneManager.LoadScene("menu");
    }

    public void QuitGame()
    {
        Debug.Log("Game is Quitting");
        Application.Quit();
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;    
    }
}
