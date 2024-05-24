using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Responder
{
    [SerializeField] private Animator animDoor = null;

    public override bool Respond(Responder aResponder, Item aItem)
    {
        if (this != aResponder)
        {
            // CANT USE THIS HERE

            return false;
        }

        SetIsDone(true);
        animDoor.SetTrigger("Open");
        AudioHandler.Instance.PlaySound("DoorOpen");
        return true;
    }
}
