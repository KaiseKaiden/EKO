using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Responder : MonoBehaviour
{
    public virtual bool Respond(Responder aResponder, Item aItem)
    {
        return false;
    }
}
