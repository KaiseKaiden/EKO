using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool myCanMove = true;

    [SerializeField] float myWalkingSpeed;
    [SerializeField] float myRotationSpeed;

    Transform myCameraTransform;
    CharacterController myCharacterController;

    Vector3 myDeciredForward;

    [SerializeField] Animator myAnimator;

    float myPositionY;

    void Start()
    {
        myCameraTransform = Camera.main.transform;
        myCharacterController = GetComponent<CharacterController>();

        myDeciredForward = transform.forward;

        myPositionY = transform.position.y;
    }

    public void SetCanMove(bool aCanMove)
    {
        myCanMove = aCanMove;
    }

    void Update()
    {
        if (myCanMove)
        {
            Movement();
        }
        else
        {
            myAnimator.SetFloat("movement", 0.0f);
        }

        Rotation();
    }

    void Movement()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector3 forward = myCameraTransform.forward;
        forward.y = 0.0f;
        forward.Normalize();

        Vector3 right = Vector3.Cross(Vector3.up, forward);
        Vector3 direction = ((right * inputX) + (forward * inputY)).normalized;

        myCharacterController.Move(direction * myWalkingSpeed * Time.deltaTime);
        myAnimator.SetFloat("movement", (direction * myWalkingSpeed).magnitude);

        if (Mathf.Abs(inputX) > 0 || Mathf.Abs(inputY) > 0)
        {
            myDeciredForward = direction;
        }

        Vector3 pos = transform.position;
        pos.y = myPositionY;
        transform.position = pos;
    }

    public void SetDeciredForward(Vector3 aForward)
    {
        myDeciredForward = aForward;
    }

    void Rotation()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(myDeciredForward), myRotationSpeed * Time.deltaTime);
    }
}
