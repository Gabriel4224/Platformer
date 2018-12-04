using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour {

    GameObject Player;
    NewPlayerMovement PlayerScript;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerScript = Player.GetComponent<NewPlayerMovement>();
	}
 
    private void    OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerScript.moveDirection.y += 30;
            PlayerScript.Health -= 10;

         }
    }
}
