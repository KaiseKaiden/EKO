using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambiance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioHandler.Instance.PlaySound("Trainloop");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
