using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquiddyWalkTrigger : MonoBehaviour
{
    [SerializeField] GameObject mySquiddy;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            mySquiddy.SetActive(true);
        }
    }
}
