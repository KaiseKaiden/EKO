using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] Transform myTargetTransform;
    [SerializeField] float myInteractDistance;
    float myInteractDistanceSqr;

    void Start()
    {
        myInteractDistanceSqr = myInteractDistance * myInteractDistance;
    }

    public bool UseItem()
    {
        float distanceSqr = (transform.position - myTargetTransform.position).sqrMagnitude;
        if (distanceSqr < myInteractDistanceSqr)
        {
            Responder responder;
            if (myTargetTransform.TryGetComponent<Responder>(out responder))
            {
                responder.Respond();
            }

            Destroy(gameObject);

            return true;
        }

        return false;
    }
}
