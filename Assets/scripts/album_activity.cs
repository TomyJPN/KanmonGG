using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class album_activity : MonoBehaviour {
  private GameObject content;
  public GameObject Node;

  public GameObject descriptionObj;
  private Text text;


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
      if (mainSystem.charaSprits.Length > i) btnImage.sprite = mainSystem.charaSprits[i];


      string tmp = i.ToString();//一時変数
      Item.GetComponent<Button>().onClick.AddListener(() => { setDescription(tmp); }); //ラムダ式とかいうやつhttps://toshusai.hatenablog.com/entry/2017/11/08/213641
    }
  }

  // Update is called once per frame
  void Update() {

  }

  void setDescription(string str) {

    descriptionObj.SetActive(true);
    text.text = mainSystem.itemInstance[int.Parse(str)].name + "\n\n" + mainSystem.itemInstance[int.Parse(str)].description;
  }

  public void activeDescription() {
    descriptionObj.SetActive(false);
  }
}
