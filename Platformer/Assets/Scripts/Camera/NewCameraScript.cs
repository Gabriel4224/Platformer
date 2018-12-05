using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class NewCameraScript : MonoBehaviour {
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 30;


    GameObject Player;
    Vector3 Offset;

    public Transform LookAt;
    public Transform CameraTransform;

    Camera Cam;

    float Distance = 10;
    float CurrentX = 0;
    float CurrentY = 0;
    public float SensitivityX;
    public float SensitivityY;

    public bool Inverted;
    float XAxis;
    float YAxis;
    // Use this for initialization
    void Start () {
        CameraTransform = transform;
        Cam = Camera.main;
        Inverted = false;
    }
    private void Update()
    {
        XAxis = XCI.GetAxis(XboxAxis.RightStickX);
        YAxis = XCI.GetAxis(XboxAxis.RightStickY);
        if (Inverted == false)
        {
            CurrentX += XAxis;
            CurrentY += YAxis;
        }
        else
        {
            CurrentX -= XAxis;
            CurrentY -= YAxis;
        }
        CurrentY = Mathf.Clamp(CurrentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }
    // Update is called once per frame
    void LateUpdate () {
      

        Vector3 Dir = new Vector3(-Distance, CurrentY * SensitivityY, 0);
        Quaternion Rot = Quaternion.Euler(CurrentY, CurrentX * SensitivityX, 0);
        CameraTransform.position = LookAt.position + Rot * Dir;
        CameraTransform.LookAt(LookAt.position);
    }
}
