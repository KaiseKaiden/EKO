using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] Image myPaperImage;

    [SerializeField] Transform myHandTransform;
    Transform myCameraTransform;
    Transform myItemTransform;
    Item myItemComponent;

    [SerializeField] LayerMask myItemLayer;
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
                    myItemComponent.UseItem();
                }

                Putdown();
            }
        }
    }

    void Pickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(myCameraTransform.position, myCameraTransform.forward, out hit, myItemLayer))
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

                myItemTransform.SetParent(myHandTransform);
                myItemTransform.position = myHandTransform.position;
                myItemTransform.rotation = myHandTransform.rotation;

                myItemComponent.PickupItem();

                // Paper Thangs
                if (myItemComponent.GetImage() != null)
                {
                    myPaperImage.enabled = true;
                    myPaperImage.sprite = myItemComponent.GetImage();
                }
            }
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
