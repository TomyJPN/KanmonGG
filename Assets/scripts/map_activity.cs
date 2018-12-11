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
  

  // Use this for initialization
  void Start() {
    if (mainSystem.isGameclear) {
      tapCharactor(mainSystem.nowCharaID);
    }
  }

  // Update is called once per frame
  void Update() {

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
