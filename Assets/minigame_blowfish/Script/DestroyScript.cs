using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour{

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Blowfish1");
	}
	
	// Update is called once per frame
	void Update () {
        float x = player.transform.position.x - transform.position.x;
        if (x > 30.0f)
        {
            Destroy(gameObject);
        }
	}
}
