using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class map_player : MonoBehaviour {
  public GameObject actionButton;
  public GameObject areaUI;
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
      //Debug.Log(nearCharaID);
    }
    if (other.gameObject.tag == "mapArea") {
      areaUI.SetActive(true);
      Text text = areaUI.transform.Find("Text").gameObject.GetComponent<Text>();
      text.text = other.name;
      //取得したTextをピッタリ収まるようにサイズ変更
      text.rectTransform.sizeDelta = new Vector2(text.preferredWidth, text.preferredHeight);
    }
  }
  private void OnTriggerExit2D(Collider2D collision) {
    if (collision.gameObject.tag == "enemy") {
      actionButton.SetActive(false);
    }
    if (collision.gameObject.tag == "mapArea") {
      areaUI.SetActive(false);
    }
  }/*
  private void OnTriggerEnter2D(Collider2D collision) {
    if (collision.gameObject.tag == "mapArea") {
      areaUI.SetActive(true);
      Text text = areaUI.transform.Find("Text").gameObject.GetComponent<Text>();
      text.text= collision.name;
      //取得したTextをピッタリ収まるようにサイズ変更
      text.rectTransform.sizeDelta = new Vector2(text.preferredWidth, text.preferredHeight);
    }
  }*/
}
