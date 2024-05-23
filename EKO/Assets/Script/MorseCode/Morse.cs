using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morse : MonoBehaviour
{
    [SerializeField] MeshRenderer myLampRenderer;
    [SerializeField] Material myUnlitMaterial;
    [SerializeField] Material myLitMaterial;

    [SerializeField] float myTimeBetweenLights;
    [SerializeField] float myTimeBetweenLetters;
    [SerializeField] float myTimeBetweenRestart;

    [SerializeField] float myDotTime;
    [SerializeField] float myLineTime;

    [SerializeField] List<string> myLetters;

    bool myIsLit = true;
    float myTime;
    int myLetterIndex;
    int myBlinkIndex;

    private void Start()
    {
        myTime = myTimeBetweenRestart;
    }

    private void Update()
    {
        myTime -= Time.deltaTime;

        if (myTime <= 0)
        {
            if (myIsLit)
            {
                myIsLit = false;
                myTime = myTimeBetweenLights;
                myLampRenderer.material = myUnlitMaterial;

                myBlinkIndex++;

                if (myBlinkIndex >= myLetters[myLetterIndex].Length - 1)
                {
                    myBlinkIndex = 0;
                    myLetterIndex++;
                    myTime = myTimeBetweenLetters;

                    if (myLetterIndex >= myLetters.Count - 1)
                    {
                        myLetterIndex = 0;
                        myTime = myTimeBetweenRestart;
                    }
                }
            }
            else
            {
                if (myLetters[myLetterIndex][myBlinkIndex] == 'l')
                {
                    myIsLit = true;
                    myTime = myLineTime;
                    myLampRenderer.material = myLitMaterial;
                }
                else
                {
                    myIsLit = true;
                    myTime = myDotTime;
                    myLampRenderer.material = myLitMaterial;
                }
            }
        }
    }
}
