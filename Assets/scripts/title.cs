using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour {
  TouchScreenKeyboard keyboard;
  // Use this for initialization
  void Start() {
    saveLoad.Load();
    if (!saveLoad.saveData.notFirstGame) {
      // キーボードを表示する
      this.keyboard = TouchScreenKeyboard.Open(saveLoad.saveData.name, TouchScreenKeyboardType.Default);
      saveLoad.Save();
    }
  }

  // Update is called once per frame
  void Update() {
    if (this.keyboard.done) {  // キーボードが閉じた時
      saveLoad.saveData.name = keyboard.text;
    }
  }
  public void OnClick() {
    SceneManager.LoadScene("map");
  }
}
