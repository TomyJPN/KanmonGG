using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
  public static bool[] kaihou=new bool[31];  //解放したか

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

    //storyJsonファイルの読み込み
    /*storyJson = File.ReadAllText("Assets/game_Data/storyData.json");
    Debug.Log("loaded JSON file:");
    Debug.Log(storyJson);
    storyInstance = JsonHelper.FromJson<Story>(storyJson);
    Debug.Log("回線丼："+storyInstance[0].story);*/

    saveLoad testData=new saveLoad();
    //testData.Save();
    for(int i = 0; i < 31; i++) {
      kaihou[i] = false;
    }
    kaihou[0] = true;
    testData.chara.kaihou = kaihou;
    testData.Save();
    testData.Load();
    kaihou = testData.chara.kaihou;
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
