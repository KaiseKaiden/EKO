using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkTrigger : MonoBehaviour
{
    [SerializeField] InkRise myInkRise;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            myInkRise.SetIsActivated(true);
        }
    }
}
