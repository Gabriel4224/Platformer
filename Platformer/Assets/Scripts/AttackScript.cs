using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class AttackScript : MonoBehaviour {
    GameObject AttackBox;
    EnemyScript Enemy;
    GameObject EnemyGameobject;
    bool Attacking;
    bool hit;
    float Cooldown = 0.5f;

    // Use this for initialization
    void Start () {
        AttackBox = GameObject.FindGameObjectWithTag("AttackBox");
        EnemyGameobject = GameObject.FindGameObjectWithTag("Enemy");
        Enemy = EnemyGameobject.GetComponent<EnemyScript>();
        AttackBox.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        Attack();
        if (Attacking)
        {
            if (hit)
            {
                Enemy.Health -= 10;
                hit = false;
            }
            Cooldown -= Time.deltaTime;
            if (Cooldown <= 0)
            {
                Cooldown = 0.5f;
                AttackBox.SetActive(false);
                Attacking = false;
            }
        }
    }
    void Attack()
    {
        if (XCI.GetButtonDown(XboxButton.X))
        {
            Debug.Log("Attack");
            AttackBox.SetActive(true);
            Attacking = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (AttackBox.gameObject.tag == "Enemy")
        {
             hit = true;
        }

    }
}
