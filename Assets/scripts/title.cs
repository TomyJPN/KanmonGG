using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour {
  TouchScreenKeyboard keyboard;
  // Use this for initialization
  void Start() {
    //mainSystem.savedata.dataLoad();
    mainSystem.dataLoad();
    if (!mainSystem.savedata.notFirstGame) {
      // キーボードを表示する
      this.keyboard = TouchScreenKeyboard.Open(saveLoad.saveData.name, TouchScreenKeyboardType.Default);
      mainSystem.savedata.startTime = DateTime.Now;
      mainSystem.dataSave();
    }
  }

  // Update is called once per frame
  void Update() {
    if (this.keyboard.done) {  // キーボードが閉じた時
      mainSystem.savedata.name = keyboard.text;
    }
  }
  public void OnClick() {
    SceneManager.LoadScene("map");
  }
}
