using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class AttackScript : MonoBehaviour {
     EnemyScript Enemy;
    GameObject EnemyGameobject;
    GameObject Player;
 
    public float Cooldown;

    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        EnemyGameobject = GameObject.FindGameObjectWithTag("Enemy");
        Enemy = EnemyGameobject.GetComponent<EnemyScript>();
        gameObject.SetActive(false);
     }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10))
        {
            Debug.Log("INRANGE");

            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("CanHitEnemy");

                if (XCI.GetButtonDown(XboxButton.X))
                {
                    Debug.Log("HITENEMY");
                    Enemy = hit.transform.gameObject.GetComponent<EnemyScript>();
                    Enemy.Health -= 10;
                }
            }

        }  
    }

 }
 
