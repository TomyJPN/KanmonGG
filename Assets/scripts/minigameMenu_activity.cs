using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class minigameMenu_activity : MonoBehaviour {

  // Use this for initialization
  void Start() {
    if (mainSystem.isGameclear) SceneManager.LoadScene("map");
  }

  // Update is called once per frame
  void Update() {

  }
  public void startBlowfish() {
    Screen.orientation = ScreenOrientation.LandscapeLeft;
    SceneManager.LoadScene("blowfishGame");
  }
  public void startsilk() {
    Screen.orientation = ScreenOrientation.LandscapeLeft;
    SceneManager.LoadScene("silkwormGame");
  }

}
