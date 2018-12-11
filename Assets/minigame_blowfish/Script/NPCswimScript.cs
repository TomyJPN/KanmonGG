using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCswimScript : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Blowfish1");
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0.1f, 0, 0);
        transform.position = new Vector3(transform.position.x, player.transform.position.y, player.transform.position.z);
    }
}
