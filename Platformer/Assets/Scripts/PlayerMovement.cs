using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
public class PlayerMovement : MonoBehaviour {

    float XAxis;
    float YAxis;
    float DefaultSpeed;
    float SpinTimer = 0.25f;

    Vector3 MoveDirection = Vector3.zero;
    Vector3 Spin;
    Vector3 TargetDirection;

    public float Speed;
    public float Jumpheight;
    public float GravityY;
    public float SprintMultiplier;

    public XboxController Controller;
    public Rigidbody rb;
    CharacterController Control;
    GameObject Guide;
    int sprint;

    bool Canjump;
    bool IsWalljumping;
    bool IsSprinting;
    bool Cutscene;
     public float RotateSpeed;
    float timer = 0.55f;
    public float SetJumpTime;

    public GameObject LookRight;
    public GameObject LookLeft;
    private Vector3 jumpVelocity = Vector3.zero;
    int Djump;
    private void Start()
    {
        timer = SetJumpTime;
        DefaultSpeed = Speed;
        Control = GetComponent<CharacterController>();
        Guide = GameObject.FindGameObjectWithTag("LookAtMe");
       
    }
    void Update()
    {
        Debug.Log(Speed);
        Vector3 CamPos = Camera.main.transform.position;
        Vector3 PlayerPos = transform.position;
        Vector3 Direction = PlayerPos - CamPos;
        Direction.Normalize();
         // TODO
        // Use a bool to lock movement during cutscenes 
        if (!Cutscene)
        {
            PlayerControls();
            WallKick();
        }
 
        //WHILE WALLJUMPING 
        if (IsWalljumping)
        {

            transform.rotation *= Quaternion.Euler(0, 140 * 5 * Time.deltaTime, 0);
             SpinTimer -= Time.deltaTime;
            // transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, Spin, 3 * Time.deltaTime);
            // till player can jump again
            if (SpinTimer <= 0)
            {
                IsWalljumping = false;
                SpinTimer = 0.25f;
            }
        }

        // SPRINT TOGGLE
        if (IsSprinting && sprint == 0)
        {
            Speed += SprintMultiplier;
            sprint++;
        }
        if (IsSprinting == false)
        {
            Speed = DefaultSpeed;
            sprint = 0;
        }
     
    }
    void PlayerControls()
    {
        XAxis = XCI.GetAxis(XboxAxis.LeftStickX);
        YAxis = XCI.GetAxis(XboxAxis.LeftStickY);
        //WHILE PLAYER IS ON THE GROUND
        if (Control.isGrounded)
        {
          
        MoveDirection = new Vector3(XAxis, 0.0f, YAxis);
        MoveDirection = Camera.main.transform.TransformDirection(MoveDirection);
        MoveDirection = MoveDirection * Speed;
        MoveDirection.y = 0;

            // transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(-XAxis, -YAxis) * Mathf.Rad2Deg, transform.eulerAngles.z);

        }

        //WHILE PLAYER IS NOT ON THE GROUND
        if (!Control.isGrounded)
        {
             if (!IsWalljumping)
            {
                
            //
            // MoveDirection.x = XAxis * 10;
            // MoveDirection.z = YAxis * 10;
            // 
            // MoveDirection = Camera.main.transform.TransformDirection(MoveDirection);
                 
            }
         }
        MoveDirection.y = MoveDirection.y - (GravityY * Time.deltaTime);
        // IF THE PLAYER CAN JUMP
        if (Canjump)
        {
            if (XCI.GetButtonDown(XboxButton.A))
            {
                MoveDirection.y = Jumpheight;
                 Djump += 1;
                if (Djump >= 2)
                {
                Canjump = false;

                }
            }
        }
        Control.Move(MoveDirection * Time.deltaTime);
    
       // SPRINTING 
       if (XCI.GetAxis(XboxAxis.LeftTrigger) > 0.35f)
        {
            IsSprinting = true;

        }
        if (XCI.GetAxis(XboxAxis.LeftTrigger) < 0.35f)
        {
            IsSprinting = false;

        }
       
        // rotate to where camera is looking
        if (XCI.GetAxis(XboxAxis.LeftStickY) > 0.55 || Input.GetKey(KeyCode.W))
         {
            TargetDirection.x = transform.position.x - Camera.main.transform.position.x;
            TargetDirection.z = transform.position.z - Camera.main.transform.position.z;
       
            Vector3 Forward = new Vector3(TargetDirection.x, 0.0f, TargetDirection.z);
            Vector3 NewDirection = Vector3.RotateTowards(transform.forward, Forward, 3 * Time.deltaTime, 0);
            transform.rotation = Quaternion.LookRotation(NewDirection);
       
        }
        if (XCI.GetAxis(XboxAxis.LeftStickY) < -0.55 ||  Input.GetKey(KeyCode.S)) 
        {
            TargetDirection.x = transform.position.x - Camera.main.transform.position.x;
            TargetDirection.z = transform.position.z - Camera.main.transform.position.z;
       
            Vector3 Forward = new Vector3(TargetDirection.x, 0.0f, TargetDirection.z);
            Vector3 NewDirection = Vector3.RotateTowards(transform.forward, -Forward, 3 * Time.deltaTime, 0);
            transform.rotation = Quaternion.LookRotation(NewDirection);
       
        }

        if (XCI.GetAxis(XboxAxis.LeftStickX) < -0.85 || Input.GetKey(KeyCode.A))
        {
        
            TargetDirection.x = transform.position.x - LookLeft.transform.position.x;
            TargetDirection.z = transform.position.z - LookLeft.transform.position.z;
        
            Vector3 Forward = new Vector3(TargetDirection.x, 0.0f, TargetDirection.z);
            Vector3 NewDirection = Vector3.RotateTowards(transform.forward, -Forward, 5 * Time.deltaTime, 0);
            transform.rotation = Quaternion.LookRotation(NewDirection);
        }
        if (XCI.GetAxis(XboxAxis.LeftStickX) > 0.85 || Input.GetKey(KeyCode.D))
        {
        
            TargetDirection.x = transform.position.x - LookRight.transform.position.x;
            TargetDirection.z = transform.position.z - LookRight.transform.position.z;
        
            Vector3 Forward = new Vector3(TargetDirection.x, 0.0f, TargetDirection.z);
            Vector3 NewDirection = Vector3.RotateTowards(transform.forward, -Forward, 5 * Time.deltaTime, 0);
            transform.rotation = Quaternion.LookRotation(NewDirection);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
      
        if(collision.gameObject.tag == "Ground")
        {

            Debug.Log("GROUNDED");
            Canjump = true;
            Djump = 0;
        }
         
    }
 


    void WallKick()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
       
        if (!Canjump)
        {
            if (Physics.Raycast(transform.position, fwd, out hit, 1.25f))
            {
                if (XCI.GetButtonDown(XboxButton.A))
                {
                    Debug.DrawRay(hit.point, hit.normal, Color.red, 1.25f);
                    MoveDirection = hit.normal * 6;
                    MoveDirection.y = 18;
                  
                    IsWalljumping = true;
                }
            }
        }
    }

    //Attacking 

}
