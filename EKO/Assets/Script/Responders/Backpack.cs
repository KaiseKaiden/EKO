using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : Responder
{
    [SerializeField] GameObject myKeyPrefab;

    public override void Respond()
    {
        myKeyPrefab.transform.position = transform.position + transform.forward;
    }
}
