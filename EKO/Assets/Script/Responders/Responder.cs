using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Responder : MonoBehaviour
{
    public virtual bool Respond(Responder aResponder)
    {
        return false;
    }
}
