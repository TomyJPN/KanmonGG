using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class album_activity : MonoBehaviour {
  private GameObject content;
  public GameObject Node;
  public GameObject NodeStory;
  public GameObject albumLay;
  public GameObject storyLay;

  public GameObject descriptionObj;
  private Text text;

  private int[] storyIDs = {0,1,3,5,10,20 };

  // Use this for initialization
  void Start() {
    text = descriptionObj.transform.Find("Text").GetComponent<Text>();

    for (int i = 0; i < mainSystem.itemInstance.Length; i++) {
      GameObject Item;
      content = GameObject.Find("Canvas/monster/ScrollView/Content");//生成する場所
      Item = Instantiate(Node, content.transform);
      Item.transform.Find("name").gameObject.GetComponent<Text>().text = mainSystem.itemInstance[i].name;

      //画像
      Image btnImage = Item.transform.Find("Image").gameObject.GetComponent<Image>();
      if (mainSystem.charaSprits.Length > i) btnImage.sprite = mainSystem.charaSprits[i]; //これなんだっけ

      string tmp = i.ToString();//一時変数
      Item.GetComponent<Button>().onClick.AddListener(() => { setDescription(tmp); }); //ラムダ式とかいうやつhttps://toshusai.hatenablog.com/entry/2017/11/08/213641

    }
    //ストーリーの生成
    for(int i = 0; i < storyIDs.Length; i++) {
      GameObject Item;
      content = GameObject.Find("Canvas/story/ScrollView/Content"); //生成する場所
      Item = Instantiate(NodeStory, content.transform);
      Item.transform.Find("name").gameObject.GetComponent<Text>().text = mainSystem.itemInstance[storyIDs[i]].name;
      Item.transform.Find("number").gameObject.GetComponent<Text>().text = "No."+storyIDs[i].ToString();
      //画像
      Image btnImage = Item.transform.Find("Image").gameObject.GetComponent<Image>();
      if (mainSystem.charaSprits.Length > i) btnImage.sprite = mainSystem.charaSprits[storyIDs[i]]; //これなんだっけ

      string tmp = storyIDs[i].ToString();
      Item.GetComponent<Button>().onClick.AddListener(() => { playStory(tmp); }); //ラムダ式とかいうやつhttps://toshusai.hatenablog.com/entry/2017/11/08/213641

    }
    storyLay.SetActive(false);  //storyレイヤ
  }

  // Update is called once per frame
  void Update() {

  }

  //オンクリックで呼び出される．説明文を設定
  void setDescription(string str) {

    descriptionObj.SetActive(true);
    text.text = mainSystem.itemInstance[int.Parse(str)].name + "\n\n" + mainSystem.itemInstance[int.Parse(str)].description ;
    if (mainSystem.savedata.kaihou[int.Parse(str)]) {
      text.text += "\n\n解放済み";
    }
    else {
      text.text += "\n\n未解放";
    }
  }

  void playStory(string str) {
    Debug.Log(str);
    mainSystem.storyPlay = true;
    mainSystem.nowCharaID = int.Parse(str)+1;
    SceneManager.LoadScene("map");
  }

  public void activeDescription() {
    descriptionObj.SetActive(false);
  }

  public void albumButton() {
    albumLay.SetActive(true);
    storyLay.SetActive(false);
  }

  public void storyButton() {
    storyLay.SetActive(true);
    albumLay.SetActive(false);
  }
}
