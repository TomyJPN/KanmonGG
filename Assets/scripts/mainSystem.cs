using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using Newtonsoft.Json;

public class mainSystem : MonoBehaviour {
  string charaJson;
  string storyJson;

  //ゲーム全体で使うstatic変数
  public static Item[] itemInstance;
  public static Sprite[] charaSprits;
  public static int nowCharaID;   //現在進行中のストーリーID
  public static bool isGameclear; //ミニゲームをクリアしたか
  public static bool storyPlay;
  public static Vector3 playerPos;
  //public static string name;

  //セーブ/////////////
  public static saveData savedata = new saveData(); //右辺こうしないとエラー出る
  public class saveData{ //キャラクターデータクラス
    public string name; //プレイヤー名
    public string syogo;  //称号
    public int level; //レベル
    public DateTime startTime; //開始時間
    public float walkDistance;  //歩いた距離
    public int storyNum;  //解放ストーリー数
    public int visitedNum;  //訪れた観光地数
    public int monsterNum; //解放モンスター数
    public bool[] kaihou = new bool[31]; //モンスターの解放(収集)
    public bool notFirstGame;
  }
 
  //データの保存を行う
  public static void dataSave() {
    if (savedata != null)//キャラデータがない場合不具合が発生している場合があるのでLogErrorとして通知しておく
    {
      string jsonStr = JsonConvert.SerializeObject(savedata); //クラスをJson化
      Debug.Log("save：" + jsonStr);
      PlayerPrefs.SetString("playerData", jsonStr); //PlayerPrefsにデータを保存　　第1引数は任意
    }
    else {
      Debug.LogError("セーブデータがないよ！");
    }
  }
  // データのロードを行う
  public static void dataLoad() {
    string loadJsonStr = PlayerPrefs.GetString("playerData", ""); //データのロード　第2引数は設定されていなかった場合の空データ設定
    Debug.Log("Load：" + loadJsonStr);
    if (string.IsNullOrEmpty(loadJsonStr)) //セーブデータがない場合無駄な処理を行わないためのif文
    {
      Debug.Log("セーブデータはないよ！");
    }
    else {
      savedata = JsonUtility.FromJson<saveData>(loadJsonStr);
    }
  }
  //  /////////////////


  void Awake() {
    DontDestroyOnLoad(this.gameObject);
  }

  void Start() {
    if (!savedata.notFirstGame) dataReset();

    //charaJsonファイルの読み込み
    charaJson = Resources.Load<TextAsset>("charaData").ToString();
    //Debug.Log("loaded JSON file:");
    //Debug.Log(charaJson);
    itemInstance = JsonHelper.FromJson<Item>(charaJson);
    charaSprits= Resources.LoadAll<Sprite>("chara/");
    isGameclear = false;
    storyPlay = false;

    playerPos = new Vector3(464f, 374f, 0);

    dataLoad();
    Debug.Log(savedata.notFirstGame);
  }

  // Update is called once per frame
  void Update() {

  }

  //テスト用初期データ
  public void dataReset() {
    for(int i = 0; i < 31; i++) {
      savedata.kaihou[i] = false;
    }
    savedata.name = "関門太郎";
    savedata.notFirstGame = false;
    savedata.syogo = "ベータ版プレイヤー";
    savedata.level = 1;
    savedata.walkDistance =0;
    savedata.startTime = DateTime.Today;
    savedata.visitedNum = 0;
    savedata.storyNum = 0; //とりあえず
    savedata.monsterNum = 0;
    dataSave();
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

