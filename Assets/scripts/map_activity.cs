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
  public GameObject player;
  private Rigidbody2D playerRg;

  // Use this for initialization
  void Start() {
    if (mainSystem.isGameclear || mainSystem.storyPlay) {
      tapCharactor(mainSystem.nowCharaID);
    }
    onController = false;
    playerRg = player.GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update() {
    float dis;
    double rad= getRadian(controllerPos.x, controllerPos.y, Input.mousePosition.x, Input.mousePosition.y);
    if (onController) {
      dis = getDistance(controllerPos.x, controllerPos.y, Input.mousePosition.x, Input.mousePosition.y);
      if (dis < 80f) {  //範囲内の操作
        controller.transform.position = Input.mousePosition;
      }
      else {          //範囲外にマウスをやった時
        float y2 = (float)Math.Sin(rad) * 80; //角度と距離から，指定半径の座標を出す
        float x2 = (float)Math.Cos(rad) * 80;
        controller.transform.position = new Vector2(x2+controllerPos.x, y2+controllerPos.y);
        dis = 80;
      }
      float y = (float)Math.Sin(rad) * dis; //角度と距離から，指定半径の座標を出す
      float x = (float)Math.Cos(rad) * dis;
      playerRg.velocity = new Vector2(x, y);  //プレイヤー移動
    }
    
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
      mainSystem.storyPlay = false;
    }
  }

  //ビックリマークのアクションボタン
  public void onActionButton() {
    tapCharactor(int.Parse(player.GetComponent<map_player>().nearCharaID));
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
    playerRg.velocity = new Vector2(0, 0);
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
