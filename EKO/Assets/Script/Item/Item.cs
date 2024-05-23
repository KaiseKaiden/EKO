using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] Image myImage;

    [SerializeField] Transform myTargetTransform;
    [SerializeField] float myInteractDistance;
    float myInteractDistanceSqr;

    Transform myCameraTransform;

    bool myIsDropping;

    Rigidbody myRigidbody;

    void Start()
    {
        myCameraTransform = Camera.main.transform;

        myInteractDistanceSqr = myInteractDistance * myInteractDistance;

        myRigidbody = GetComponent<Rigidbody>();
    }

    public bool UseItem()
    {
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

    public void DropItem()
    {
        myRigidbody.isKinematic = false;
    }

    public void PickupItem()
    {
        myRigidbody.isKinematic = true;
    }

    public Image GetImage()
    {
        return myImage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        myRigidbody.isKinematic = true;
    }
}
