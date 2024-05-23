using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Responder
{
    [SerializeField] private Animator animDoor = null;

    public override void Respond()
    {
        animDoor.Play("DoorTest");
    }

    void Update()
    {
        // Example of playing a sound on a key press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animDoor.Play("DoorTest");
            AudioHandler.Instance.PlaySound("DoorOpen");
        }
    }



}
