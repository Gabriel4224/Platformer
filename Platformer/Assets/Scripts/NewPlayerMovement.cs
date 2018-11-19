using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class NewPlayerMovement : MonoBehaviour {


    private float XAxis;
    private float YAxis;

    public float Speed;
    public float Jump;

    bool CanJump;
    Rigidbody rb;
    public CharacterController CharControl;
    public XboxController Controller;
    public float gravScale;
    Vector3 moveDirection;
    int Djump;
    // Use this for initialization
    void Start () {
        //        rb = GetComponent<Rigidbody>();
        CharControl = GetComponent<CharacterController>();


    }

    // Update is called once per frame
    void Update ()
    {

        XAxis = XCI.GetAxis(XboxAxis.LeftStickX);
        YAxis = XCI.GetAxis(XboxAxis.LeftStickY);

        // moveDirection = new Vector3(XAxis * Speed, moveDirection.y, YAxis * Speed);

        float YStore = moveDirection.y;
        moveDirection = (Camera.main.transform.forward * YAxis  ) + (Camera.main.transform.right * XAxis  );
        moveDirection = moveDirection.normalized * Speed;
        moveDirection.y = YStore;
        if (CharControl.isGrounded)
        {
            moveDirection.y = 0;
            if (XCI.GetButtonDown(XboxButton.A))
            {
 
                moveDirection.y = Jump;
 
            }
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y   * gravScale * Time.deltaTime);
        CharControl.Move(moveDirection * Time.deltaTime);

         

    }
 
}

