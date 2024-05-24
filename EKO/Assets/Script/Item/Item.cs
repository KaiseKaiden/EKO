using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] Sprite myImage;
    [SerializeField] Responder myTargetResponder;

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

    public bool ShowIndicator()
    {
        RaycastHit hit;
        if (Physics.Raycast(myCameraTransform.position, myCameraTransform.forward, out hit))
        {
            Responder responder;
            if (hit.transform.TryGetComponent<Responder>(out responder))
            {
                if (myTargetResponder == responder)
                {

                    Vector3 playerPos = transform.position;
                    playerPos.y = myCameraTransform.position.y;

                    float distanceSqr = (playerPos - hit.point).sqrMagnitude;
                    if (distanceSqr < myInteractDistanceSqr)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
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
                    if (responder.Respond(myTargetResponder, this))
                    {
                        Destroy(gameObject);

                        AudioHandler.Instance.PlaySound("useitem");
                        
                        return true;
                    }
                }
            }
        }

        return false;
    }

    public void DropItem()
    {
        myRigidbody.isKinematic = false;
        if (myImage != null)
        {
            AudioHandler.Instance.PlaySound("notedrop");
        }
        else AudioHandler.Instance.PlaySound("dropitem");
    }

    public void PickupItem()
    {
        myRigidbody.isKinematic = true;

        if (myImage != null)
        {
            AudioHandler.Instance.PlaySound("note");
        }
        else AudioHandler.Instance.PlaySound("pickup");
    }

    public Sprite GetImage()
    {
        return myImage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        myRigidbody.isKinematic = true;
    }
}
