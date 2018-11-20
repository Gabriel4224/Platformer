using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class NewPlayerMovement : MonoBehaviour {


    private float XAxis;
    private float YAxis;

    public float Speed;

    float DefaultSpeed;
    bool IsSprinting;
    int SprintToggle;
    public float Jump;

    bool CanJump;
    Rigidbody rb;
    public CharacterController CharControl;
    public XboxController Controller;
    public float gravScale;
    Vector3 moveDirection;
    int Djump;
    // Use this for initialization
    void Start() {
        //        rb = GetComponent<Rigidbody>();
        CharControl = GetComponent<CharacterController>();

        DefaultSpeed = Speed ;
    }

    // Update is called once per frame
    void Update()
    {

         Movement();
     
    }

    void Movement()
    {
        XAxis = XCI.GetAxis(XboxAxis.LeftStickX);
        YAxis = XCI.GetAxis(XboxAxis.LeftStickY);

        // moveDirection = new Vector3(XAxis * Speed, moveDirection.y, YAxis * Speed);

        float YStore = moveDirection.y;
        moveDirection = (Camera.main.transform.forward * YAxis) + (Camera.main.transform.right * XAxis);
        moveDirection = moveDirection.normalized * Speed;
        moveDirection.y = YStore;
        // Jump 
        if (CharControl.isGrounded)
        {
            CanJump = true;

            moveDirection.y = 0;
            if (XCI.GetButtonDown(XboxButton.A))
            {

                moveDirection.y = Jump;
                CanJump = true;
            }
            
        }
        // Double Jump
        else
        {
             
             if (XCI.GetButtonDown(XboxButton.A) && CanJump)
            {

                moveDirection.y = Jump;
                CanJump = false;
            }
        }
        if (IsSprinting && SprintToggle == 0)
        {
            Speed *= 1.5f;
            SprintToggle++;
        }
        if (IsSprinting == false)
        {
            Speed = DefaultSpeed;
            SprintToggle = 0;
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravScale * Time.deltaTime);
        CharControl.Move(moveDirection * Time.deltaTime);

        if(XCI.GetAxis(XboxAxis.LeftTrigger) > 0.35)
        {
            IsSprinting = true;
        }
        else
        {
            IsSprinting = false;

            Speed = DefaultSpeed;
         }
    }

    
}

