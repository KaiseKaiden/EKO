using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class MorsePoster : MonoBehaviour
{
    [SerializeField] Transform myStaticCameraTransform;

    CameraMovement myCameraMovement;
    GameObject myPlayer;

    bool myIsUsing;

    private void Start()
    {
        myCameraMovement = Camera.main.GetComponent<CameraMovement>();
        myPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Input.GetButtonDown("Exit") && myIsUsing)
        {
            Exit();
        }
    }

    private void Exit()
    {
        myIsUsing = false;

        myPlayer.SetActive(true);

        myCameraMovement.SetState(CameraMovement.eState.InGame);
    }

    private void OnMouseDown()
    {
        myIsUsing = true;

        myPlayer.SetActive(false);

        myCameraMovement.SetState(CameraMovement.eState.Static);
        myCameraMovement.SetStaticTransform(myStaticCameraTransform);
    }
}
