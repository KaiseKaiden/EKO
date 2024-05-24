using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquiddyJumpscare : MonoBehaviour
{
    [SerializeField] GameObject mySquiddyJumpscare;
    PlayerMovement myPlayerMovement;

    void Start()
    {
        myPlayerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            myPlayerMovement.SetCanMove(false);
            mySquiddyJumpscare.SetActive(true);
 	AudioHandler.Instance.PlaySound("jumpscare2");

        }
    }
}
