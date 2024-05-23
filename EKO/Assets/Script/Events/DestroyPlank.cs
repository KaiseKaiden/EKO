using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlank : MonoBehaviour
{
    [SerializeField] GameObject myPlank;
    [SerializeField] Responder myResponder;

    public void DestroyThePlank()
    {
        Destroy(myPlank);

        myResponder.Respond(myResponder);
    }

    public void DestroyMyself()
    {
        Destroy(transform.parent.gameObject);
    }
}
