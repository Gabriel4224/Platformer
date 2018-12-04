using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Talking : MonoBehaviour {

    bool Pause;
    float Timer = 0.05f;
    NPCInteractable TriggerConvo;
    DialogueManager dialogue;
    GameObject DialogueManagerGameobject;
    public GameObject Talk;

    private void Start()
    {
        DialogueManagerGameobject = GameObject.FindGameObjectWithTag("DialogueManager");
        dialogue = DialogueManagerGameobject.GetComponent<DialogueManager>();
        Talk.SetActive(false);

    }
    private void Update()
    {
        if(XCI.GetButtonDown(XboxButton.B) && Pause)
        {
            dialogue.DisplayNextSentence();
            Pause = false;
        }
         if(Pause == false)
        {
            Timer -= Time.deltaTime;
            if(Timer <= 0)
            {
                Pause = true;
                Timer = 0.05f;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "NPC")
        {
            Debug.Log("NPC");

            if (XCI.GetButtonDown(XboxButton.B) && dialogue.IsTalking == false)
            {
                dialogue.DialogBox.SetActive(true);
                dialogue.IsTalking = true;
                TriggerConvo = other.transform.gameObject.GetComponent<NPCInteractable>();
                TriggerConvo.TriggerDialogue();
                Pause = false;
            }
            Talk.SetActive(true);
        }
    }

}
