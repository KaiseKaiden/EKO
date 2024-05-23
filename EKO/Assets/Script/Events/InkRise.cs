using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkRise : MonoBehaviour
{
    [SerializeField] Vector3 myStartPos;
    [SerializeField] Vector3 myEndPos;

    [SerializeField] float myTimeTilDeath;
    [SerializeField] SceneLoaderOnTrigger mySceneLoaderOnTrigger;
    float myTime;

    bool myIsActive;
    bool myCanBeActivated = true;
    bool myIsDead;

    private void Start()
    {
        myTimeTilDeath = (1.0f / myTimeTilDeath);
    }

    private void Update()
    {
        if (myIsActive)
        {
            myTime += Time.deltaTime * myTimeTilDeath;
        }
        else
        {
            myTime -= Time.deltaTime;
            myTime = Mathf.Clamp01(myTime);
        }

        transform.position = myStartPos + ((myEndPos - myStartPos) * myTime);

        if (myTime > 1.0f)
        {
            if (!myIsDead)
            {
                mySceneLoaderOnTrigger.RestartScene();
                myIsDead = true;
            }
        }
    }

    public void SetIsActivated(bool aBool)
    { 
        if (!aBool)
        {
            myCanBeActivated = false;
        }

        if (myCanBeActivated)
        {
            myIsActive = aBool;
        }
    }

}
