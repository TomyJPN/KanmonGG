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
  public GameObject controller;
  private bool onController;
  Vector3 controllerPos;


  // Use this for initialization
  void Start() {
    if (mainSystem.isGameclear) {
      tapCharactor(mainSystem.nowCharaID);
    }
    onController = false;
  }

  // Update is called once per frame
  void Update() {
    if (onController) {
      float dis = getDistance(controllerPos.x, controllerPos.y, Input.mousePosition.x, Input.mousePosition.y);
      if (dis < 80f) {  //範囲内の操作
        Debug.Log(getDistance(controllerPos.x,controllerPos.y,Input.mousePosition.x,Input.mousePosition.y));
        controller.transform.position = Input.mousePosition;
      }
      else {          //範囲外にマウスをやった時
        double rad = getRadian(controllerPos.x, controllerPos.y, Input.mousePosition.x, Input.mousePosition.y);
        float y2 = (float)Math.Sin(rad) * 80; //角度と距離から，指定半径の座標を出す
        float x2 = (float)Math.Cos(rad) * 80;
        controller.transform.position = new Vector2(x2+controllerPos.x, y2+controllerPos.y);
      }
    }
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

  //コントローラーを押したとき
  public void onClickController() {
    onController = true;
    controllerPos = controller.transform.position;
  }
  //コントローラーを離したとき
  public void outClickController() {
    onController = false;
    controller.transform.position = controllerPos;
  }
  //2点間の距離
  protected float getDistance(double x, double y, double x2, double y2) {
    double distance = Math.Sqrt((x2 - x) * (x2 - x) + (y2 - y) * (y2 - y));

    return (float)distance;
  }
  //2点間の角度
  protected double getRadian(double x, double y, double x2, double y2) {
    double radian = Math.Atan2(y2 - y, x2 - x);
    return radian;
  }
  //radianをdegreeに変換
  protected double ToAngle(double radian) {
    return (double)(radian * 180 / Math.PI);
  }
}
