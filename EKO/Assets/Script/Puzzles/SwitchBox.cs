using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBox : MonoBehaviour
{
    [SerializeField] Switch[] mySwitches = new Switch[6];
    [SerializeField] bool[] myIsOn = new bool[6];

    [SerializeField] Transform myCameraPosition;
    [SerializeField] float myInteractDistance;
    float myInteractDistanceSqr;
    CameraMovement myCameraMovement;
    GameObject myPlayer;

    bool myIsUsing;

    BoxCollider myCollider;

    private void Start()
    {
        myInteractDistanceSqr = myInteractDistance * myInteractDistance;

        myCollider = GetComponent<BoxCollider>();

        myCameraMovement = Camera.main.GetComponent<CameraMovement>();
        myPlayer = GameObject.FindGameObjectWithTag("Player");

        for (int i = 0; i < mySwitches.Length; i++)
        {
            mySwitches[i].SetIsOn(myIsOn[i]);
            mySwitches[i].SetSwitchbox(this);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Leave") && myIsUsing)
        {
            myPlayer.SetActive(true);

            myIsUsing = false;
            myCollider.enabled = true;
            myCameraMovement.SetState(CameraMovement.eState.InGame);
        }
    }

    public bool IsUsing()
    {
        return myIsUsing;
    }

    private void OnMouseDown()
    {
        Vector3 playerPos = myPlayer.transform.position;
        playerPos.y = transform.position.y;

        float distanceSqr = (playerPos - transform.position).sqrMagnitude;
        if (distanceSqr < myInteractDistanceSqr)
        {
            myPlayer.SetActive(false);

            myIsUsing = true;
            myCollider.enabled = false;

            myCameraMovement.SetStaticTransform(myCameraPosition);
            myCameraMovement.SetState(CameraMovement.eState.Static);
        }
    }
}
