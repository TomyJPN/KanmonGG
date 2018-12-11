using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuBar : MonoBehaviour {
  public GameObject messageUI;
  private GameObject canvas;

  // Use this for initialization
  void Start() {
    canvas = GameObject.Find("Canvas");
  }

  // Update is called once per frame
  void Update() {

  }


  public void buttonMap() {
    Debug.Log("map");
    SceneManager.LoadScene("map");
  }
  public void buttonProfiel() {
    Debug.Log("profiel");
    SceneManager.LoadScene("profile");
  }
  public void buttonAlbum() {
    Debug.Log("album");
    SceneManager.LoadScene("album");
  }
  public void buttonHelp() {
    Debug.Log("help");
    SceneManager.LoadScene("help");
  }

  //画面上に警告等指定したメッセージを表示
  public void showMessage(string str) {
    Text text;
    GameObject prefab = (GameObject)Instantiate(messageUI);
    prefab.transform.SetParent(canvas.transform, false);    //UIはCanvasの子にする
    text = prefab.transform.Find("Text").gameObject.GetComponent<Text>();
    text.text = str;
  }
}
