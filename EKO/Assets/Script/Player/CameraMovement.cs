using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float myCameraSpeed;
    [SerializeField] float myMaxCameraDistance;
    [SerializeField] float myRightDistance;
    [SerializeField] float myUpDistance;
    [SerializeField] float myClampAngle;

    [SerializeField] LayerMask myCameraLayer;

    float myCurrentDistance;
    float myDeciredDistance;

    float lookX;
    float lookY;

    Vector3 myStaticPosition;
    Vector3 myStaticRotation;

    public enum eState
    {
        InGame,
        Static
    }

    eState myState = eState.InGame;

    public void SetStaticTransform(Transform aTransform)
    {
        myStaticPosition = aTransform.position;
        myStaticRotation = aTransform.eulerAngles;
    }

    public void SetState(eState aState)
    {
        myState = aState;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        myCurrentDistance = myMaxCameraDistance;
    }

    void Update()
    {
        if (myState == eState.InGame)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            float inputX = Input.GetAxis("Mouse X");
            float inputY = Input.GetAxis("Mouse Y");

            lookX += -inputY * myCameraSpeed * Time.deltaTime;
            lookY += inputX * myCameraSpeed * Time.deltaTime;
            lookX = Mathf.Clamp(lookX, -myClampAngle, myClampAngle);
            transform.eulerAngles = new Vector3(lookX, lookY, 0.0f);

            SetCurrentDistance();

            Vector3 centerPosition = Vector3.up * myUpDistance + transform.right * myRightDistance;
            transform.localPosition = centerPosition - transform.forward * myCurrentDistance;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            transform.position = myStaticPosition;
            transform.eulerAngles = myStaticRotation;
        }
    }

    void SetCurrentDistance()
    {
        Vector3 centerPosition = Vector3.up * myUpDistance + transform.right * myRightDistance;

        RaycastHit hit;

        if (Physics.Raycast(transform.parent.transform.position + centerPosition, -transform.forward, out hit, myMaxCameraDistance, myCameraLayer))
        {
            myDeciredDistance = hit.distance;
            if (myCurrentDistance > myDeciredDistance)
            {
                myCurrentDistance = myDeciredDistance;
            }
        }
        else
        {
            myDeciredDistance = myMaxCameraDistance;
        }

        myCurrentDistance = Mathf.Lerp(myCurrentDistance, myDeciredDistance, 2.0f * Time.deltaTime);
    }
}
