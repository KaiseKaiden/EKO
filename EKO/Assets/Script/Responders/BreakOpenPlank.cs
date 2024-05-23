using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOpenPlank : Responder
{
    public GameObject myCrowbar;

    public override void Respond()
    {
        myCrowbar.SetActive(true);
    }
}
