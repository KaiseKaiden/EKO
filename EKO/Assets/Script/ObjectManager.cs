using UnityEngine;
using System.Collections.Generic;

public class ObjectManager : MonoBehaviour
{
    [Tooltip("List of objects to disable.")]
    public List<GameObject> objectsToDisable;

    [Tooltip("List of objects to enable.")]
    public List<GameObject> objectsToEnable;

    private ObjectManager objectManager;

    private void Start()
    {
        // Find the ObjectManager component in the scene
        objectManager = FindObjectOfType<ObjectManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the collider has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Call the method to manage objects
            objectManager.ManageObjects();
        }
    }

    // Method to disable and enable the specified objects
    public void ManageObjects()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
            else
            {
                Debug.LogWarning("An object to disable is missing!");
            }
        }

        foreach (GameObject obj in objectsToEnable)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
            else
            {
                Debug.LogWarning("An object to enable is missing!");
            }
        }
    }
}

    

