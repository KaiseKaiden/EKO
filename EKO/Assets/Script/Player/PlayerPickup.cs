using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;
using Unity.Burst.CompilerServices;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] GameObject myPickup;
    [SerializeField] Text myClueText;
    [SerializeField] GameObject myUse;

    [SerializeField] Image myPaperImage;
    [SerializeField] Animator myAnimator;

    [SerializeField] Transform myHandTransform;
    Transform myCameraTransform;
    Transform myItemTransform;
    Item myItemComponent;

    [SerializeField] LayerMask myItemLayer;
    [SerializeField] LayerMask myEverythingLayer;
    [SerializeField] float myInteractRange;
    float myInteractRangeSqr;

    bool myInHand = false;

    private void Start()
    {
        myCameraTransform = Camera.main.transform;

        myInteractRangeSqr = myInteractRange * myInteractRange;
    }

    void Update()
    {
        myPickup.SetActive(false);
        myClueText.enabled = false;
        myUse.SetActive(false);

        if (!ReciverIndicator())
        {
            if (!myInHand)
            {
                PickupIndicator();
            }
            else
            {
                if (myItemComponent)
                {
                    if (myItemComponent.ShowIndicator())
                    {
                        myUse.SetActive(true);
                    }
                }
            }
        }

        if (Input.GetButtonDown("Interact"))
        {
            if (!myInHand)
            {
                Pickup();
            }
            else
            {
                if (myItemComponent)
                {
                    if (myItemComponent.UseItem())
                    {
                        myInHand = false;
                    }
                }
            }
        }

        if (Input.GetButtonDown("Release"))
        {
            if (myInHand)
            {
                Putdown();
            }
        }
    }

    void PickupIndicator()
    {
        if (Physics.Raycast(myCameraTransform.position, myCameraTransform.forward, myInteractRange, myItemLayer, QueryTriggerInteraction.Ignore))
        {
            myPickup.SetActive(true);
        }
    }

    bool ReciverIndicator()
    {
        RaycastHit hit;
        if (Physics.Raycast(myCameraTransform.position, myCameraTransform.forward, out hit, myInteractRange, myEverythingLayer, QueryTriggerInteraction.Ignore))
        {
            Responder responder;
            if (hit.transform.TryGetComponent<Responder>(out responder))
            {
                if (responder.GetIsDone())
                {
                    return false;
                }

                myClueText.text = responder.GetClue();
                myClueText.enabled = true;

                return true;
            }
        }

        return false;
    }

    void Pickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(myCameraTransform.position, myCameraTransform.forward, out hit, myInteractRange, myItemLayer, QueryTriggerInteraction.Ignore))
        {
            float distanceSqr = (hit.point - transform.position).sqrMagnitude;
            if (distanceSqr > myInteractRangeSqr)
            {
                return;
            }

            Item item;
            if (hit.transform.TryGetComponent<Item>(out item))
            {
                myItemComponent = item;
                myItemTransform = hit.transform;
                myInHand = true;

                myAnimator.SetTrigger("Interact");

                {
                    PlayerMovement movement = gameObject.GetComponent<PlayerMovement>();
                    movement.SetCanMove(false);

                    Vector3 lookDir = (myItemTransform.position - transform.position);
                    lookDir.y = 0.0f;
                    movement.SetDeciredForward(lookDir.normalized);
                }
            }
        }
    }

    public void PickemUp()
    {
        myItemTransform.SetParent(myHandTransform);
        myItemTransform.position = myHandTransform.position;
        myItemTransform.localPosition = myItemComponent.GetPositionOffset();
        myItemTransform.localEulerAngles = myItemComponent.GetRotationOffset();

        myItemComponent.PickupItem();

        // Paper Thangs
        if (myItemComponent.GetImage() != null)
        {
            myPaperImage.enabled = true;
            myPaperImage.sprite = myItemComponent.GetImage();
        }
    }

    void Putdown()
    {
        myItemComponent.DropItem();

        myInHand = false;
        myItemComponent = null;
        myItemTransform.SetParent(null);
        myItemTransform = null;

        myPaperImage.enabled = false;
    }
}
