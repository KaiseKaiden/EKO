using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Numpad : MonoBehaviour
{
    [SerializeField] NumpadButton[] myButtons;
    [SerializeField] Transform myStaticCameraTransform;
    [SerializeField] MeshRenderer myLampMeshRenderer;
    [SerializeField] Material mySuccessMaterial;

    [SerializeField] Responder myResponder;

    [SerializeField] string myCode;
    int myCodeIndex;

    bool myIsDone;
    bool myIsUsing;

    BoxCollider myCollider;
    CameraMovement myCameraMovement;
    GameObject myPlayer;

    void Start()
    {
        myCollider = GetComponent<BoxCollider>();
        myCameraMovement = Camera.main.GetComponent<CameraMovement>();
        myPlayer = GameObject.FindGameObjectWithTag("Player");

        myCodeIndex = 0;

        for (int i = 0; i < myButtons.Length; i++)
        {
            myButtons[i].InitButton(this);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Exit") && myIsUsing)
        {
            Exit();
        }
    }

    public void SendNumber(int aIndex)
    {
        if ((int)char.GetNumericValue(myCode[myCodeIndex]) == aIndex)
        {
            myCodeIndex++;

            if (myCodeIndex >= myCode.Length)
            {
                myIsDone = true;
                Exit();

                myLampMeshRenderer.material = mySuccessMaterial;
                myResponder.Respond(myResponder);
            }
        }
        else
        {
            myCodeIndex = 0;
            if ((int)char.GetNumericValue(myCode[myCodeIndex]) == aIndex)
            {
                myCodeIndex++;
            }
        }
    }

    private void Exit()
    {
        myIsUsing = false;

        if (!GetIsDone())
        {
            myCollider.enabled = true;
        }

        myPlayer.SetActive(true);

        myCameraMovement.SetState(CameraMovement.eState.InGame);
    }

    public bool GetIsDone()
    {
        return myIsDone;
    }

    private void OnMouseDown()
    {
        myIsUsing = true;

        myCollider.enabled = false;
        myPlayer.SetActive(false);

        myCameraMovement.SetState(CameraMovement.eState.Static);
        myCameraMovement.SetStaticTransform(myStaticCameraTransform);
    }
}
