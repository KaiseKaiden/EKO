using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField] GameObject myCanvas;

    CameraMovement myCameraMovement;

    private void Start()
    {
        myCameraMovement = Camera.main.GetComponent<CameraMovement>();
    }

    public void TheEnd()
    {
        myCameraMovement.SetState(CameraMovement.eState.Static);

        myCanvas.SetActive(true);
    }
}
