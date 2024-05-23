using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    public Animator doorAnimator;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the collider has the tag "Player"
        if (other.CompareTag("Player"))
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object exiting the collider has the tag "Player"
        if (other.CompareTag("Player"))
        {
            CloseDoor();
        }
    }

    private void OpenDoor()
    {
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Open");
        }
    }

    private void CloseDoor()
    {
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Close");
        }
    }
}
