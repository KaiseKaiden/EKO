using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDown : MonoBehaviour
{
    [SerializeField] Responder myDoorResponder;

    public void DoneEE()
    {
        myDoorResponder.Respond(myDoorResponder, new Item());
    }
}
