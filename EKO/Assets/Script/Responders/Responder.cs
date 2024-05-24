using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Responder : MonoBehaviour
{
    public string myClue;
    bool myIsDone;

    public void SetIsDone(bool aBool)
    {
        myIsDone = aBool;
    }

    public bool GetIsDone()
    {
        return myIsDone;
    }

    public virtual string GetClue()
    {
        return myClue;
    }

    public virtual bool Respond(Responder aResponder, Item aItem)
    {
        return false;
    }
}
