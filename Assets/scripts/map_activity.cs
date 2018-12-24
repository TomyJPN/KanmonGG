using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class map_activity : MonoBehaviour {
  public GameObject storyBack;
  string[] story1;
  public Text showStory;   //反映してるストーリー文
  private int StoryNum;   //タップ数
  //public GameObject canvas;  //canvas

  public GameObject Player;
  //public GameObject moveUIpref;
  //public GameObject moveUI;
  

  // Use this for initialization
  void Start() {
    if (mainSystem.isGameclear) {
      tapCharactor(mainSystem.nowCharaID);
    }
  }

  // Update is called once per frame
  void Update() {
    /*if (Input.GetMouseButtonDown(0)) {  //押された瞬間
      moveUI = Instantiate(moveUIpref) as GameObject;
      moveUI.transform.parent = canvas.transform;
      moveUI.transform.position = Input.mousePosition;
      //worldPos = Camera.main.ScreenToWorldPoint(startPos);
      //moveUI.transform.position = new Vector3(worldPos.x, worldPos.y, 10.0f);
    }
    if (Input.GetMouseButton(0)) {
      this.movePos = Input.mousePosition;
      if (this.movePos.y > this.startPos.y && transform.position.y < 3.8f) {
        transform.Translate(0, 0.1f, 0);
        for (i = 0; i < scoreScript.i; i++) {
          StartCoroutine(DelayMethod(15 * (i + 1), i, 1));
        }
      }
      if (this.movePos.y < this.startPos.y && transform.position.y > -3.8f) {
        transform.Translate(0, -0.1f, 0);
        for (i = 0; i < scoreScript.i; i++) {
          StartCoroutine(DelayMethod(15 * (i + 1), i, -1));
        }
      }

      moveUI.transform.Translate(0.1f + (0.01f * scoreScript.i), 0, 0);
      if (j != scoreScript.i) {
        moveUI.transform.Translate(-0.01f, 0, 0);
        k++;
        if (k == 50) {
          j++;
          k = 0;
        }
      }

    }
    if (Input.GetMouseButtonUp(0)) {
      //this.startPos = this.movePos;
      Destroy(moveUI);
    }*/
  }


  //マップ上のキャラがタップされたときとゲームクリア時に呼び出される
  public void tapCharactor(int charaId) {
    string path;
    string storyText;
    int B_A = 1;  //ストーリーbefore/after
    if (mainSystem.isGameclear) B_A = 2;
    mainSystem.nowCharaID = charaId;

    storyBack.SetActive(true);
    path = "story/story_" + charaId + "_"+B_A;
    //storyText = File.ReadAllText(path);     //読み込み (旧)
    storyText = Resources.Load<TextAsset>(path).ToString();

    story1 = storyText.Split(new string[] { "\r\n" },StringSplitOptions.None);  //改行で分割
    for (int i = 0; i < story1.Length; i++) {
      Debug.Log(story1[i]);
    }
    StoryNum = 0;
    showStory.text = story1[StoryNum];

    //画像変更
    storyBack.transform.Find("charaImage").gameObject.GetComponent<Image>().sprite = mainSystem.charaSprits[charaId-1];
  }

  public void tapText() {
    StoryNum++;
    if (StoryNum < story1.Length) { 
      showStory.text = story1[StoryNum];
    }
    else if(StoryNum == story1.Length && !mainSystem.isGameclear) {
      Debug.Log("end");
      storyBack.transform.Find("gameButton").gameObject.SetActive(true);
    }
    else if (mainSystem.isGameclear) {
      storyBack.SetActive(false);
      storyBack.transform.root.transform.Find("MAPImage/charas/" + mainSystem.nowCharaID).gameObject.SetActive(false);
      mainSystem.isGameclear = false;
    }
  }

  public void startGame() {
    SceneManager.LoadScene("minigameMenu");
  }
}
