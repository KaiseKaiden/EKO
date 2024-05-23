using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Responder
{
    [SerializeField] private Animator animDoor = null;

    public override void Respond()
    {
        animDoor.SetTrigger("Open");
    }
}
