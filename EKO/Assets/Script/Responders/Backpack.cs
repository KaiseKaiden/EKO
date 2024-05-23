using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : Responder
{
    [SerializeField] GameObject myKeyPrefab;

    public override bool Respond(Responder aResponder, Item aItem)
    {
        if (this != aResponder)
        {
            // CANT USE HERE
            return false;
        }

        myKeyPrefab.transform.position = transform.position + transform.forward;
        return true;
    }
}
