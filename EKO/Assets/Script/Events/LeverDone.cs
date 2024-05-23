using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDone : MonoBehaviour
{
    int myDone;

    [SerializeField] Animator myLeverAnimator;

    public void Done()
    {
        myDone++;

        if (myDone >= 2)
        {
            myLeverAnimator.SetTrigger("Pull");
        }
    }
}
