using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] Transform myHandTransform;
    Transform myCameraTransform;
    Transform myItemTransform;
    Item myItemComponent;

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
        GameObject closest = null;
        float closestDistanceSqr = float.MaxValue;
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("Item"))
        {
            if (i.transform == myItemTransform)
            {
                continue;
            }

            float distanceSqr = (i.transform.position - transform.position).sqrMagnitude;
            if (distanceSqr < myInteractRangeSqr)
            {
                closest = i;
                closestDistanceSqr = distanceSqr;
            }
        }

        if (closest != null)
        {
            closest.TryGetComponent<Item>(out myItemComponent);
            myItemTransform = closest.transform;
            myInHand = true;

            myItemTransform.SetParent(myHandTransform);
            myItemTransform.position = myHandTransform.position;
            myItemTransform.rotation = myHandTransform.rotation;
        }
    }

    void Putdown()
    {
        myInHand = false;
        myItemComponent = null;
        myItemTransform.SetParent(null);
        myItemTransform = null;
    }
}
