using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] Transform myTarget;

    void LateUpdate()
    {
        transform.position = myTarget.position;
    }
}
