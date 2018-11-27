using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {


    public float Health = 20;
    public float Attack;
    //public float Speed;
    NewPlayerMovement PlayerScript;
    GameObject Player;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerScript = Player.GetComponent<NewPlayerMovement>();
	}

    // Update is called once per frame
    void Update()
    {

        if (Health <= 0)
        {
            gameObject.SetActive(false);
        }
        Vector3 Position = transform.position;
        Vector3 PlayerPosition = Player.transform.position;
        Vector3 Direction = Position - PlayerPosition;
        Direction.Normalize();
        float dist = Vector3.Distance(PlayerPosition, Position);

        if (dist <= 8)
        {
            AttackPlayer();
        }
   	}
    
    void AttackPlayer()
    {
        transform.LookAt(Player.transform.position);
        transform.position += transform.forward * 0 * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerScript.Health -= Attack;
        }
    }
}
