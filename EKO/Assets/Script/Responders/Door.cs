using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Responder
{
    public override void Respond()
    {
        Destroy(gameObject);
    }
}
