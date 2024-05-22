using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] Transform myTargetTransform;
    [SerializeField] float myInteractDistance;
    float myInteractDistanceSqr;

    Transform myCameraTransform;

    void Start()
    {
        myCameraTransform = Camera.main.transform;

        myInteractDistanceSqr = myInteractDistance * myInteractDistance;
    }

    public bool UseItem()
    {
        //float distanceSqr = (transform.position - myTargetTransform.position).sqrMagnitude;
        //if (distanceSqr < myInteractDistanceSqr)
        //{
        //    Responder responder;
        //    if (myTargetTransform.TryGetComponent<Responder>(out responder))
        //    {
        //        responder.Respond();
        //    }

        //    Destroy(gameObject);

        //    return true;
        //}

        RaycastHit hit;
        if (Physics.Raycast(myCameraTransform.position, myCameraTransform.forward, out hit))
        {
            Responder responder;
            if (hit.transform.TryGetComponent<Responder>(out responder))
            {
                Vector3 playerPos = transform.position;
                playerPos.y = myCameraTransform.position.y;

                float distanceSqr = (playerPos - hit.point).sqrMagnitude;
                if (distanceSqr < myInteractDistanceSqr)
                {
                    responder.Respond();

                    Destroy(gameObject);

                    return true;
                }
            }
        }

        return false;
    }
}
