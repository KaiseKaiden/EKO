using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Responder
{
    [SerializeField] GameObject myOilAnimation;
    [SerializeField] GameObject myLever;
    [SerializeField] Item myOilItem;
    [SerializeField] Item myLeverItem;

    [SerializeField] LeverDone myLeverDone;

    public override bool Respond(Responder aResponder, Item aItem)
    {
        if (this != aResponder)
        {
            return false;
        }

        if (aItem == myOilItem)
        {
            myOilAnimation.SetActive(true);
            AudioHandler.Instance.PlaySound("oilcan");

        }
        else if (aItem == myLeverItem)
        {
            myLever.SetActive(true);
            myLeverDone.Done();
        }

        return true;
    }
}
