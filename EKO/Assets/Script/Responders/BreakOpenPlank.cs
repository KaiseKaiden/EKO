using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOpenPlank : Responder
{
    public GameObject myCrowbar;

    public override bool Respond(Responder aResponder, Item aItem)
    {
        if (this != aResponder)
        {
            // CANT USE HERE

            return false;
        }

        SetIsDone(true);
        myCrowbar.SetActive(true);
        return true;
    }
}
