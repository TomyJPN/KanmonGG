using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class help_activity : MonoBehaviour {
  public GameObject option_obj;
  public GameObject howtoplay_obj;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
  public void onOptionButton() {
    option_obj.gameObject.SetActive(true);
  }
  public void onCloseButton() {
    option_obj.gameObject.SetActive(false);
  }
  public void onHowtoplayButton() {
    howtoplay_obj.SetActive(true);
  }
  public void onCloseHowtoplay() {
    howtoplay_obj.SetActive(false);
  }
}
