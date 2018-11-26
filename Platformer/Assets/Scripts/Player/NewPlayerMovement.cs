using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class NewPlayerMovement : MonoBehaviour {


    private float XAxis;
    private float YAxis;

    public float Speed;
    public Shop ShopScript;
    GameObject Canvas;

    float DefaultSpeed;
    bool IsSprinting;
    int SprintToggle;
    public float Jump;
    Vector3 TargetDirection;

    bool CanJump;
    bool Grounded;

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
        Canvas = GameObject.FindGameObjectWithTag("Canvas");
        ShopScript = Canvas.GetComponent<Shop>();
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
            Grounded = true;
            moveDirection.y = 0;
            if (XCI.GetButtonDown(XboxButton.A))
            {
                Grounded = false;

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
        // Toggles between sprinting and jogging
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
        // Gives gravity to players Y axis 
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravScale * Time.deltaTime);
        CharControl.Move(moveDirection * Time.deltaTime);
        // Checks if players hit box is hitting the ground
        if (Grounded)
        {
            // Activates sprint 
            if (XCI.GetAxis(XboxAxis.LeftTrigger) > 0.35)
            {
                IsSprinting = true;
            }
            else
            {
                IsSprinting = false;

                Speed = DefaultSpeed;
            }
        }
        //rotates player towards the forward (Faces player away camera) 
        if (XCI.GetAxis(XboxAxis.LeftStickY) > 0.55 || Input.GetKey(KeyCode.W))
        {
            TargetDirection.x = transform.position.x - Camera.main.transform.position.x;
            TargetDirection.z = transform.position.z - Camera.main.transform.position.z;

            Vector3 Forward = new Vector3(TargetDirection.x, 0.0f, TargetDirection.z);
            Vector3 NewDirection = Vector3.RotateTowards(transform.forward, Forward, 3 * Time.deltaTime, 0);
            transform.rotation = Quaternion.LookRotation(NewDirection);

        }
        // roates player negative to its forward (Faces player towards camera)
        if (XCI.GetAxis(XboxAxis.LeftStickY) < -0.55 || Input.GetKey(KeyCode.S))
        {
            TargetDirection.x = transform.position.x - Camera.main.transform.position.x;
            TargetDirection.z = transform.position.z - Camera.main.transform.position.z;

            Vector3 Forward = new Vector3(TargetDirection.x, 0.0f, TargetDirection.z);
            Vector3 NewDirection = Vector3.RotateTowards(transform.forward, -Forward, 3 * Time.deltaTime, 0);
            transform.rotation = Quaternion.LookRotation(NewDirection);

        }
 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Vendor")
        {
            Debug.Log("Vendor ignores you");
            ShopScript.menu.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Vendor")
        {
            Debug.Log("Vendor ignores you");
            ShopScript.menu.SetActive(false);
        }
    }
}

