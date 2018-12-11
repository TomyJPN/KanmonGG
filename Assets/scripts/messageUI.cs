using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messageUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("delete",1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void delete() {
        Destroy(this.gameObject);
    }
}
