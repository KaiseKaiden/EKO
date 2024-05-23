using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel : MonoBehaviour
{
    [SerializeField] float myLengthOfTunnel;
    [SerializeField] float mySpeed;

    float myExtraLength;

    void Start()
    {
        myExtraLength = transform.position.z;
    }

    void Update()
    {
        transform.Translate(new Vector3(0.0f, 0.0f, -mySpeed) * Time.deltaTime);

        if (transform.position.z < -myLengthOfTunnel + myExtraLength)
        {
            transform.Translate(new Vector3(0.0f, 0.0f, myLengthOfTunnel));
        }
    }
}
