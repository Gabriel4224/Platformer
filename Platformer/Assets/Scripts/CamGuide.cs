using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamGuide : MonoBehaviour {
    GameObject Player;
    Vector3 Offset;
    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
         Offset = new Vector3(0, 1, 0);

    }

    // Update is called once per frame
    void Update () {
        transform.position = Player.transform.position + Offset;

    }
}
