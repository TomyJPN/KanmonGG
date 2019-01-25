using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class profile_activity : MonoBehaviour {
  public GameObject textObj1;
  public GameObject textObj2;

  // Use this for initialization
  void Start() {
    textObj1.transform.Find("name").GetComponent<Text>().text = mainSystem.savedata.name;
    textObj1.transform.Find("syogo").GetComponent<Text>().text = mainSystem.savedata.syogo;
    textObj1.transform.Find("level").GetComponent<Text>().text = mainSystem.savedata.level.ToString();
    textObj2.transform.Find("startDay").GetComponent<Text>().text = mainSystem.savedata.startTime.ToString();
    textObj2.transform.Find("walkDistance").GetComponent<Text>().text = mainSystem.savedata.walkDistance.ToString()+"km";
    textObj2.transform.Find("visitedNum").GetComponent<Text>().text = mainSystem.savedata.visitedNum.ToString() + "地点";
    textObj2.transform.Find("storyNum").GetComponent<Text>().text = mainSystem.savedata.storyNum.ToString() + "個";
    textObj2.transform.Find("monsterNum").GetComponent<Text>().text = mainSystem.savedata.monsterNum.ToString() + "体";
  }

  // Update is called once per frame
  void Update() {

  }
}
