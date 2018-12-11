using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class blowfishActivity : MonoBehaviour {

	// Use this for initialization
	void Start () {
    Screen.orientation = ScreenOrientation.LandscapeLeft;
  }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void endGame() {
    Screen.orientation = ScreenOrientation.Portrait;
    SceneManager.LoadScene("minigameMenu");
    }
}
