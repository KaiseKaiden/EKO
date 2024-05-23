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
    [SerializeField] float myOffsetMax;
    [SerializeField] float myOffsetSpeed;

    [SerializeField] LayerMask myCameraLayer;

    float myCurrentDistance;
    float myDeciredDistance;

    float lookX;
    float lookY;

    Vector2 perlinX;
    Vector2 perlinY;

    public enum eState
    {
        InGame,
        Static
    }

    eState myState = eState.InGame;
    Transform myStaticTransform;

    public void SetState(eState aState)
    {
        myState = aState;
    }

    public void SetStaticTransform(Transform aTransform)
    {
        myStaticTransform = aTransform;
    }

    private void Start()
    {
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

            NoiceOffset();
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            transform.position = myStaticTransform.position;
            transform.rotation = myStaticTransform.rotation;
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

    void NoiceOffset()
    {
        perlinX += Vector2.right * myOffsetSpeed * Time.deltaTime;
        perlinY += Vector2.up * myOffsetSpeed * Time.deltaTime;

        float sampleX = Mathf.PerlinNoise(perlinX.x, perlinX.y);
        float sampleY = Mathf.PerlinNoise(perlinY.x, perlinY.y);

        transform.Rotate(new Vector3(sampleX, sampleY, 0.0f) * myOffsetMax);
    }
}
