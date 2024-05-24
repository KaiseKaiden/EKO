using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumpadButton : MonoBehaviour
{
    Numpad myNumpad;
    [SerializeField] int myIndex;

    Vector3 myStartPosition;

    void Start()
    {
        myStartPosition = transform.localPosition;
    }

    public void InitButton(Numpad aNumpad)
    {
        myNumpad = aNumpad;
    }

    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, myStartPosition, 2.0f * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        myNumpad.SendNumber(myIndex);

        transform.localPosition = new Vector3(myStartPosition.x, myStartPosition.y, 0.0f);
        AudioHandler.Instance.PlaySound("keyinput");
    }
}
