using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class AttackScript : MonoBehaviour {
     EnemyScript Enemy;
    GameObject EnemyGameobject;
    bool Attacking;
    bool hit;
    public float Cooldown;

    // Use this for initialization
    void Start () {
        EnemyGameobject = GameObject.FindGameObjectWithTag("Enemy");
        Enemy = EnemyGameobject.GetComponent<EnemyScript>();
        gameObject.SetActive(false);
     }
	
	// Update is called once per frame
	void Update () {
        Attack();
        if (Attacking)
        {
            if (hit)
            {
                 hit = false;
                Enemy.Health -= 10;
            }
            Cooldown -= Time.deltaTime;
            if (Cooldown <= 0)
            {
                Debug.Log("Attack false");
                Cooldown = 0.5f;
                 Attacking = false;
            }
        }
    }
    void Attack()
    {
        if (XCI.GetButtonDown(XboxButton.X) && Attacking == false)
        {
            Debug.Log("Attack");
            Attacking = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
         
            if (other.gameObject.tag == "Enemy" && Attacking == false)
            {
                if (XCI.GetButtonDown(XboxButton.X))
                {
                    Debug.Log("Hit");
                    hit = true;
                }
            }
        
    }
}
