using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public static AudioHandler Instance;

    public AudioSource audioSource;
    public AudioClip[] audioClips;

    private void Awake()
    {
        // Ensure there is only one instance of the AudioHandler
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(string clipName)
    {
        AudioClip clip = GetClipByName(clipName);
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("Audio clip not found: " + clipName);
        }
    }

    private AudioClip GetClipByName(string clipName)
    {
        foreach (var clip in audioClips)
        {
            if (clip.name == clipName)
            {
                return clip;
            }
        }
        return null;
    }
}
