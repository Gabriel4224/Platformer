using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class CameraScript : MonoBehaviour {


    GameObject Guide;
    GameObject Player;
    PlayerMovement PlayerScript;
    NewPlayerMovement PlayerScriptrb;

    Vector3 Offset;
    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        Guide = GameObject.FindGameObjectWithTag("LookAtMe");
        PlayerScript = Player.GetComponent<PlayerMovement>();
        PlayerScriptrb = Player.GetComponent<NewPlayerMovement>();

        Offset = new Vector3(-5, 0, 0);
    }

    // Update is called once per frame
    void Update ()
    {
        //Calls cam Rotate function 
        CameraRotate();
        Vector3 ClampedPosition = transform.position;
        ClampedPosition.y = Mathf.Clamp(transform.position.y, Player.transform.position.y, Player.transform.position.y + 8);
        
        transform.position = ClampedPosition;
        transform.LookAt(Player.transform.position);
        Guide.transform.position = Player.transform.position;
    }
    void CameraRotate()
    {
     //   if (XCI.GetAxis(XboxAxis.RightStickY, PlayerScript.Controller) > 0.5)
     //   {
     //       transform.position += new Vector3(0, 10 * Time.deltaTime, 0);
     //   }
     //   if (XCI.GetAxis(XboxAxis.RightStickY, PlayerScript.Controller) < -0.5)
     //   {
     //       transform.position -= new Vector3(0, 10 * Time.deltaTime, 0);
     //   }
     //   if (XCI.GetAxis(XboxAxis.RightStickX, PlayerScript.Controller) > 0.25 || Input.GetKey(KeyCode.E))
     //   {
     //       Guide.transform.Rotate(0, 90 * Time.deltaTime * 2, 0);
     //   }
     //   if (XCI.GetAxis(XboxAxis.RightStickX, PlayerScript.Controller) < -0.25)
     //   {
     //       Guide.transform.Rotate(0, 90 * Time.deltaTime * -2, 0);
     //   }
     //
        if(XCI.GetAxis(XboxAxis.RightStickY, PlayerScriptrb.Controller) > 0.5)
        {
            transform.position += new Vector3(0, 10 * Time.deltaTime, 0);
        }
        if (XCI.GetAxis(XboxAxis.RightStickY, PlayerScriptrb.Controller) < -0.5)
        {
            transform.position -= new Vector3(0, 10 * Time.deltaTime, 0);
        }
        if (XCI.GetAxis(XboxAxis.RightStickX, PlayerScriptrb.Controller) > 0.25 || Input.GetKey(KeyCode.E))
        {
            Guide.transform.Rotate(0, 90 * Time.deltaTime * 2, 0);
        }
        if (XCI.GetAxis(XboxAxis.RightStickX, PlayerScriptrb.Controller) < -0.25)
        {
            Guide.transform.Rotate(0, 90 * Time.deltaTime * -2, 0);
        }
        //  if (XCI.GetAxis(XboxAxis.RightStickX, PlayerScript.Controller) > 0.5)
        //  {
        //      transform.position += new Vector3(10 * Time.deltaTime,0 , 0);
        //  }
        //  if (XCI.GetAxis(XboxAxis.RightStickX, PlayerScript.Controller) < -0.5)
        //  {
        //      transform.position -= new Vector3(10 * Time.deltaTime, 0 , 10 * Time.deltaTime);
        //  }
    }
}
