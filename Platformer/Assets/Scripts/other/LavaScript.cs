using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour {

    GameObject Player;
    NewPlayerMovement PlayerScript;
    bool BurnCooldown;
    float BurnTimer = 0.25f;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerScript = Player.GetComponent<NewPlayerMovement>();
	}
    private void Update()
    {
        if (BurnCooldown)
        {
            BurnTimer -= Time.deltaTime;
            if(BurnTimer <= 0)
            {
                BurnCooldown = false;
                BurnTimer = 0.25f;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && BurnCooldown == false)
        {
            PlayerScript.moveDirection.y += 20;
            PlayerScript.Health -= 10;

         }
    }
}
