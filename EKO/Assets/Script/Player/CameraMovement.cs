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

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        myCurrentDistance = myMaxCameraDistance;
    }

    void Update()
    {
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
