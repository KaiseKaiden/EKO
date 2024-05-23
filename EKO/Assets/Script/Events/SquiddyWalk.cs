using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquiddyWalk : MonoBehaviour
{
    [SerializeField] float myWalkingSpeed;
    Transform myCameraTransform;

    bool myHasLokkedBack;

    void Start()
    {
        myCameraTransform = Camera.main.transform;
    }

    void Update()
    {
        if (!myHasLokkedBack)
        {
            Vector3 direction = (transform.position - myCameraTransform.position).normalized;

            if (Vector3.Dot(direction, myCameraTransform.forward) > 0.2f)
            {
                myHasLokkedBack = true;
            }
        }
        else
        {
            transform.Translate(transform.forward * myWalkingSpeed * Time.deltaTime);
        }
    }
}
