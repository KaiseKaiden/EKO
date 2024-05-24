using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTiming : MonoBehaviour
{
    [SerializeField] PlayerMovement myPlayerMovement;
    [SerializeField] PlayerPickup myPlayerPickup;

    public void StartMovingAgain()
    {
        myPlayerMovement.SetCanMove(true);
    }

    public void PickupItem()
    {
        myPlayerPickup.PickemUp();
    }
}
