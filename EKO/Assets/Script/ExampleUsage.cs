using UnityEngine;

public class ExampleUsage : MonoBehaviour
{
    void Start()
    {
        // Play a sound with the name "MySound"
        AudioHandler.Instance.PlaySound("Trainloop");
    }

    void Update()
    {
        // Example of playing a sound on a key press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioHandler.Instance.PlaySound("DoorOpen");
        }
    }
}
