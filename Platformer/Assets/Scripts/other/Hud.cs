using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {


    public Text test;
    GameObject Player; 
    Collectables CollectableScript;
    public int CollectableCount;
 	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        CollectableScript = Player.GetComponent<Collectables>();
      }

    // Update is called once per frame
    void Update ()
    {
        test.text = " " + CollectableScript.CollectablesPickUp;

    }
}
