using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private void Start()
    {
        if (GameObject.FindGameObjectsWithTag("AudioManager").Length > 2)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }
}
