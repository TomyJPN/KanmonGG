using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_player : MonoBehaviour {
  public GameObject actionButton;
  //マップ上のキャラ選択関連
  public string nearCharaID;

  // Use this for initialization
  void Start() {

  }

  // Update is called once per frame
  void Update() {

  }

  private void OnTriggerStay2D(Collider2D other) {
    if (other.gameObject.tag == "enemy") {
      actionButton.SetActive(true);
      nearCharaID = other.name;
      Debug.Log(nearCharaID);
    }
  }
  private void OnTriggerExit2D(Collider2D collision) {
    if (collision.gameObject.tag == "enemy") {
      actionButton.SetActive(false);
    }
  }
}
