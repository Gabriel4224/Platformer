using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour {

    private GameObject Player;
    private Rigidbody rb;
    public int CollectablesPickUp;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = Player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            CollectablesPickUp++;
            Destroy(other.gameObject);
        }
    }
}
