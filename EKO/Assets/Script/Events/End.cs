using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField] GameObject myCanvas;

    public void TheEnd()
    {
        myCanvas.SetActive(true);
    }
}
