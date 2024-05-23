using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Responder
{
    [SerializeField] private Animator animDoor = null;

    public override bool Respond(Responder aResponder)
    {
        if (this != aResponder)
        {
            // CANT USE THIS HERE

            return false;
        }

        animDoor.SetTrigger("Open");
        return true;
    }
}
