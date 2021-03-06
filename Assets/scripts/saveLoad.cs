﻿using UnityEngine;
using System;     //DateTime
using Newtonsoft.Json;  //http://spi8823.hatenablog.com/entry/2016/04/16/001641

//https://qiita.com/ryouhei_de/items/4551ee549d2cfe81c72f より

public class saveLoad : MonoBehaviour {
  public class saveData //キャラクターデータクラス
  {
    public static string name; //プレイヤー名
    public static string syogo;  //称号
    public static int level; //レベル
    public static DateTime startTime; //開始時間

    public static float walkDistance;  //歩いた距離
    public static int storyNum;  //解放ストーリー数
    public static int visitedNum;  //訪れた観光地数
    public static int monsterNum; //解放モンスター数

    public static bool[] kaihou=new bool[31]; //モンスターの解放(収集)
    public static bool notFirstGame;

    /*public string userName = "デザートイーグル";
    public int userLV = 50;
    public int birthdayYear = 1979;
    public string comment = "中二病の象徴";
    public int[] haitetsu = { 1, 2 };*/
  }

  public static saveData chara=new saveData(); //右辺こうしないとエラー出る

  /// <summary>
  /// データの保存を行う
  /// </summary>
  public static void Save() {
    if (chara != null)//キャラデータがない場合不具合が発生している場合があるのでLogErrorとして通知しておく
    {
      string jsonStr = JsonConvert.SerializeObject(chara); //クラスをJson化
      Debug.Log("古いsave："+jsonStr);
      PlayerPrefs.SetString("playerData", jsonStr); //PlayerPrefsにデータを保存　　第1引数は任意
    }
    else {
      Debug.LogError("セーブデータがないよ！");
    }
  }

  /// <summary>
  /// データのロードを行う
  /// </summary>
  public static void Load() {
    string loadJsonStr = PlayerPrefs.GetString("playerData", ""); //データのロード　第2引数は設定されていなかった場合の空データ設定
    Debug.Log("古いLoad："+loadJsonStr);
    if (string.IsNullOrEmpty(loadJsonStr)) //セーブデータがない場合無駄な処理を行わないためのif文
    {
      Debug.Log("セーブデータはないよ！");
    }
    else {
      chara = JsonUtility.FromJson<saveData>(loadJsonStr);
    }

  }
}