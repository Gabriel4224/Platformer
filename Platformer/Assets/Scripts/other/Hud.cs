using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;
using UnityEngine.SceneManagement;

public class Hud : MonoBehaviour {


    public Text test;
    GameObject Player;
    public GameObject Menu;
    GameObject Camera;

    Collectables CollectableScript;
    CameraScript CamScript;
    public int CollectableCount;

     public int MenuToggle;
    public int InvertCamToggle;

    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        CollectableScript = Player.GetComponent<Collectables>();
        CamScript = Camera.GetComponent<CameraScript>();
        Menu.SetActive(false);
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        test.text = " " + CollectableScript.CollectablesPickUp;
        if (XCI.GetButtonDown(XboxButton.Start))
        {
            MenuToggle += 1;
        }

        switch (MenuToggle)
        {
            case 1:
                Menu.SetActive(true);
                Time.timeScale = 0;

                break;
            case 2:
                Menu.SetActive(false);
                Time.timeScale = 1;
                break;
            case 3:
                MenuToggle = 1;
                break;
        }

        switch (InvertCamToggle)
        {
            case 1:
                CamScript.Inverted = false;
                break;
            case 2:
                CamScript.Inverted = true;
                break;
            case 3:
                InvertCamToggle = 1;
                break;

        }

    }
    
    public void Invert()
    {
            InvertCamToggle += 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level1");

    }
}
