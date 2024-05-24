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

    bool myOilFixed;
    bool myLeverFixed;

    public override bool Respond(Responder aResponder, Item aItem)
    {
        if (this != aResponder)
        {
            return false;
        }

        if (aItem == myOilItem)
        {
            myOilFixed = true;

            myOilAnimation.SetActive(true);
            AudioHandler.Instance.PlaySound("oilcan");
        }
        else if (aItem == myLeverItem)
        {
            myLeverFixed = true;

            myLever.SetActive(true);
            myLeverDone.Done();
        }

        if (myLeverFixed && myOilFixed)
        {
            SetIsDone(true);
        }

        return true;
    }

    public override string GetClue()
    {
        if (!myLeverFixed && !myOilFixed)
        {
            return "Looks like its missing some parts";
        }
        else if (!myLeverFixed)
        {
            return "Looks like its still missing something";
        }
        else
        {
            return "Cant get it down";
        }

    }
}
