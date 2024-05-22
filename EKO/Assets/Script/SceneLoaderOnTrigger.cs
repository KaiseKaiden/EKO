using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderOnTrigger : MonoBehaviour
{
    [Tooltip("The name of the scene to load when the collider is entered.")]
    public string sceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the collider has the tag "Player"
        if (other.CompareTag("Player"))
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        // Check if the scene is valid before attempting to load it
        if (Application.CanStreamedLevelBeLoaded(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Scene " + sceneToLoad + " cannot be loaded. Please check the scene name and ensure it is added to the Build Settings.");
        }
    }
}
