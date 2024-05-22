using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] Transform myLever;
    [SerializeField] float myRotationOffset = 30.0f;
    bool myIsOn;

    SwitchBox mySwitchBox;

    public void SetIsOn(bool aBool)
    {
        myIsOn = aBool;

        SetLeverAngle();
    }

    public void SetSwitchbox(SwitchBox aSwitchBox)
    {
        mySwitchBox = aSwitchBox;
    }

    void SetLeverAngle()
    {
        if (myIsOn)
        {
            myLever.eulerAngles = new Vector3(myRotationOffset, 0.0f, 0.0f);
        }
        else
        {
            myLever.eulerAngles = new Vector3(-myRotationOffset, 0.0f, 0.0f);
        }
    }

    private void OnMouseDown()
    {
        if (!mySwitchBox.IsUsing())
        {
            return;
        }

        myIsOn = !myIsOn;

        SetLeverAngle();
    }
}
