using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public int number;

    public GameObject menu;
    GameObject Collectable;
    Collectables CollectableScript;
    AttackScript attackScript;
    GameObject Door;
    GameObject Sword;
    public GameObject ShopText;
    public GameObject ShopCam;
    bool PurchasedSword = false;
    bool PurchasedDoor = false;

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
    }
	
	// Update is called once per frame
	void Update () {
		

        switch (number)
        {
            case 1:
                if (CollectableScript.CollectablesPickUp >= 25 && !PurchasedDoor)
                {
                    Debug.Log("A");
                    CollectableScript.CollectablesPickUp -= 25;
                    Door.SetActive(false);
                    PurchasedDoor = true;
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
