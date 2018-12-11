using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class album_description : MonoBehaviour {
    public Text text;

    public void OnClick(int id) {
       text.text = mainSystem.itemInstance[id].description;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
