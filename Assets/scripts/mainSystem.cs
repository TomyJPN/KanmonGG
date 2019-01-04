using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class mainSystem : MonoBehaviour {
  string charaJson;
  string storyJson;

  //ゲーム全体で使うstatic変数
  public static Item[] itemInstance;
  public static Sprite[] charaSprits;
  public static int nowCharaID;   //現在進行中のストーリーID
  public static bool isGameclear; //ミニゲームをクリアしたか
  public static bool storyPlay;
  //public static string name;

  void Awake() {
    DontDestroyOnLoad(this.gameObject);

  }

  void Start() {
    //charaJsonファイルの読み込み
    //charaJson = File.ReadAllText("Assets/game_Data/charaData.json");
    charaJson = Resources.Load<TextAsset>("charaData").ToString();
    Debug.Log("loaded JSON file:");
    Debug.Log(charaJson);
    itemInstance = JsonHelper.FromJson<Item>(charaJson);
    for (int i = 0; i < itemInstance.Length; i++) {
      Debug.Log("id:"+itemInstance[i].id+"\nname:"+ itemInstance[i].name+"\ndescription:"+ itemInstance[i].description);
    }

    charaSprits= Resources.LoadAll<Sprite>("chara/");
    /*for(int i = 1; i <= 31; i++) {
      string path = "chara/";
      charaSprits[i] = Resources.Load<Sprite>(path+i+".png");
      
    }*/
    isGameclear = false;
    storyPlay = false;

    //storyJsonファイルの読み込み
    /*storyJson = File.ReadAllText("Assets/game_Data/storyData.json");
    Debug.Log("loaded JSON file:");
    Debug.Log(storyJson);
    storyInstance = JsonHelper.FromJson<Story>(storyJson);
    Debug.Log("回線丼："+storyInstance[0].story);*/

    //試験用のセーブデータ(要改善)
    saveLoad testData=new saveLoad();
    //testData.Save();
    for(int i = 0; i < 31; i++) {
      saveLoad.saveData.kaihou[i] = false;
    }
    saveLoad.saveData.kaihou[0] = true;
    saveLoad.saveData.name ="関門太郎";
    saveLoad.saveData.syogo = "カンモンマスター";
    saveLoad.saveData.level = 10;
    saveLoad.saveData.walkDistance = 1.3f;
    saveLoad.saveData.startTime = DateTime.Today;
    testData.Save();
    testData.Load();
  }

  // Update is called once per frame
  void Update() {

  }

}


[System.Serializable]
public class Item {
  public int id;
  public string name;
  public string description;
}

[System.Serializable]
public class Story {
  public int id;
  public string story;
}
