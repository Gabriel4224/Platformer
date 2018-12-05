using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame : MonoBehaviour {

    DialogueManager Dialogue;
    public GameObject GameCamera;
    public GameObject MiniGameObject;
    public GameObject TimerObject;
    GameObject DialogueManagerGameObject;
    GameObject Game;
    public float GameCamTimer = 1;
    // Checks if the game is in Progress
    bool GameActivated;
    // Checks if the player has Won
    bool PlayerWon;
    // Text displays current time
    public Text text;
    // InGame TImer
     public float GameTimer;

    float TimerGoAway = 3;
    private void Start()
    {
        Game = GameObject.FindGameObjectWithTag("MiniGame");
        DialogueManagerGameObject = GameObject.FindGameObjectWithTag("DialogueManager");
        Dialogue = DialogueManagerGameObject.GetComponent<DialogueManager>();
        Game.SetActive(false);
        GameActivated = false;
        GameCamera.SetActive(false);
        TimerObject.SetActive(false);
    }
    // Update is called once per frame
    void Update ()
    {

	    if(Dialogue.IsTalking == false && Dialogue.ActivateMiniGame == true)
        {
         GameActivated = true;
         Game.SetActive(true);
        }

        if (GameActivated == true)
        {
            TimerObject.SetActive(true);
            //Ingame Timer 
            GameTimer -= Time.deltaTime;
            //CameraBool Timer
            GameCamTimer -= Time.deltaTime;
            text.text = "" + GameTimer;
            GameCamera.SetActive(true);
            if (GameCamTimer <= 0)
            {
                GameCamera.SetActive(false);
            }
            if (MiniGameObject.transform.childCount == 0)
            {
                Debug.Log("YOUWIN");
                PlayerWon = true;
                GameActivated = false;
                Dialogue.ActivateMiniGame = false;
            }
            if(GameTimer <= 0 && MiniGameObject.transform.childCount >= 0)
            {
                PlayerWon = false;
                GameActivated = false;
                Game.SetActive(false);

            }
        }

        if(PlayerWon)
        {
            text.text = "YOU WON THE \n  MINIGAME";
            TimerGoAway -= Time.deltaTime;
            if(TimerGoAway <= 0)
            {
                TimerObject.SetActive(false);
            }
        }
        if (PlayerWon == false && GameActivated == false)
        {
            text.text = "Better luck next time";
            TimerObject.SetActive(false);
  
        }
    }
 }
 
