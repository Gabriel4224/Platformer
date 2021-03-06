﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

    int TouristNumber;
    public GameObject TouristDialogue;
    public GameObject Talk;

    public Text text;
    bool pause = true;
    bool talking;
    float PauseTimer = 0.05f;
    bool HasTalkedToTourist;
    int TestPatience;
    GameObject Player;
    NewPlayerMovement PlayerScript;
    // Use this for initialization
    void Start()
    {
        TouristNumber = 0;
        TouristDialogue.SetActive(false);
           Player = GameObject.FindGameObjectWithTag("Player");
           PlayerScript = Player.GetComponent<NewPlayerMovement>();
        Talk.SetActive(false);
        talking = false;
    }

    /// Update is called once per frame
    void Update()
    {
        if(talking)
        {
            Debug.Log("ISTALKING");
            if (XCI.GetButtonDown(XboxButton.B))
            {
                TouristNumber++;
            }
            TouristDialogue.SetActive(true);
            pause = false;
            PlayerScript.CanMove = false;
        }
         if (pause == false)
        {
            PauseTimer -= Time.deltaTime;
            if (PauseTimer <= 0)
            {
                pause = true;
                PauseTimer = 0.05f;
            }
        }

        switch (TouristNumber)
        {
            case 1:
                {
                    if (TestPatience >= 4)
                    {
                        TouristNumber += 6;

                    }
                    if (HasTalkedToTourist && TestPatience <= 3)
                    {
                        TouristNumber += 4;
                    }
                    if(HasTalkedToTourist == false)
                    {
                        text.text = "Im not really sure how i ended up here";
                    }
                }

                break;
            case 2:
                {
                    text.text = "But it beats having to go to work so....";

                }

                break;
            case 3:
                {
                    text.text = "Why are you still looking at me?";
                    HasTalkedToTourist = true;
                }

                break;
            case 4:
                {
                    TouristDialogue.SetActive(false);
                    PlayerScript.CanMove = true;
                    TouristNumber = 0;
                    talking = false;
                }
                break;
            case 5:
                {
                    text.text = "Can you stop staring at me?!?";
                    HasTalkedToTourist = true;
                }
                break;
            case 6:
                {
                    TouristDialogue.SetActive(false);
                    PlayerScript.CanMove = true;
                    TouristNumber = 0;
                    TestPatience++;
                    talking = false;

                }
                break;
            case 7:
                {
                    text.text = "You think you're funny huh?";
                    HasTalkedToTourist = true;
                }
                break;
            case 8:
                {
                    text.text = "Bugging me on my accidental vacation";
                    HasTalkedToTourist = true;
                }
                break;
            case 9:
                {
                    text.text = "Shame on you!";
                    HasTalkedToTourist = true;
                }
                break;
            case 10:
                {
                    TouristDialogue.SetActive(false);
                    PlayerScript.CanMove = true;
                    TouristNumber = 0;
                    talking = false;

                }
                break;
        }




    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Tourist")
        {
            Talk.SetActive(true);
            Debug.Log("Speak To frien");
            if (XCI.GetButtonDown(XboxButton.B))
            {
                Debug.Log("TALKING");
                talking = true;
               
            }
        }
    }
 
}
