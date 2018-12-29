using UnityEngine;
using Newtonsoft.Json;  //http://spi8823.hatenablog.com/entry/2016/04/16/001641

//https://qiita.com/ryouhei_de/items/4551ee549d2cfe81c72f より

class saveLoad : MonoBehaviour {
  public class CharacterData //キャラクターデータクラス
  {
    public string userName = "デザートイーグル";
    public int userLV = 50;
    public int birthdayYear = 1979;
    public string comment = "中二病の象徴";
    public int[] haitetsu = { 1, 2 };
  }

  CharacterData chara = new CharacterData();

  /// <summary>
  /// データの保存を行う
  /// </summary>
  public void Save() {
    if (chara != null)//キャラデータがない場合不具合が発生している場合があるのでLogErrorとして通知しておく
    {
      string jsonStr = JsonConvert.SerializeObject(chara); //クラスをJson化
      Debug.Log("save："+jsonStr);
      PlayerPrefs.SetString("playerData", jsonStr); //PlayerPrefsにデータを保存　　第1引数は任意
    }
    else {
      Debug.LogError("キャラクターデータがないよ！");
    }
  }

  /// <summary>
  /// データのロードを行う
  /// </summary>
  public void Load() {
    string loadJsonStr = PlayerPrefs.GetString("playerData", ""); //データのロード　第2引数は設定されていなかった場合の空データ設定
    Debug.Log("Load："+loadJsonStr);
    if (string.IsNullOrEmpty(loadJsonStr)) //セーブデータがない場合無駄な処理を行わないためのif文
    {
      Debug.Log("セーブデータはないよ！");
    }
    else {
      CharacterData loadClass = JsonUtility.FromJson<CharacterData>(loadJsonStr);
    }

  }
}