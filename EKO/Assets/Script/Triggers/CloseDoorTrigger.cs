using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorTrigger : MonoBehaviour
{
    [SerializeField] Animator myAnimator;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            myAnimator.SetTrigger("Close");
        }
    }
}
