using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public int number;
    float DoorAnimTimer = 1.25f;
    public GameObject menu;
    GameObject Collectable;
    Collectables CollectableScript;
    AttackScript attackScript;
    GameObject Door;
    GameObject Sword;
    public GameObject ShopText;
    public GameObject ShopCam;
    public GameObject DoorCam;

    bool PurchasedSword = false;
    bool PurchasedDoor = false;
    bool DoorOpenAnim = false;
    public Animator BridgeAnim;
    // Use this for initialization
    void Start () {
        Door = GameObject.FindGameObjectWithTag("Door");
        Sword = GameObject.FindGameObjectWithTag("Sword");
        attackScript = Sword.GetComponent<AttackScript>();
        Collectable = GameObject.FindGameObjectWithTag("Player");
        CollectableScript = Collectable.GetComponent<Collectables>();
        menu.SetActive(false);
        ShopText.SetActive(false);
        ShopCam.SetActive(false);
        DoorCam.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
        if (DoorOpenAnim)
        {
            DoorAnimTimer -= Time.deltaTime;
            if(DoorAnimTimer <= 0)
            {
                DoorCam.SetActive(false);
                DoorOpenAnim = false;
                menu.SetActive(true);

            }
        }
        switch (number)
        {
            case 1:
                if (CollectableScript.CollectablesPickUp >= 25 && !PurchasedDoor)
                {
                    Debug.Log("A");
                    CollectableScript.CollectablesPickUp -= 25;
                     PurchasedDoor = true;
                    BridgeAnim.SetBool("IsBridgeOpen", true);
                    DoorCam.SetActive(true);
                    DoorOpenAnim = true;
                    menu.SetActive(false);

                }
                else
                {
                    Debug.Log("NotENough");
                }
                number = 0;
                break;
            case 2:
                if (CollectableScript.CollectablesPickUp >= 10 && !PurchasedSword)
                {
                    Debug.Log("B");
                    CollectableScript.CollectablesPickUp -= 10;
                    attackScript.gameObject.SetActive(true);
                    PurchasedSword = true;
                }
                else
                {
                    Debug.Log("NotENough");
                }
                number = 0;
                break;
            case 3:
                Debug.Log("C");
                number = 0;
                break;
            

        }
	}

    public void OpenDoor()
    {
        number = 1;
    }
    public void GetWeapon()
    {
        number = 2;
    }
}
