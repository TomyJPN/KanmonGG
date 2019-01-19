using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class profile_activity : MonoBehaviour {
  public GameObject textObj;

  // Use this for initialization
  void Start() {
    textObj.transform.Find("name").GetComponent<Text>().text = mainSystem.savedata.name;
    textObj.transform.Find("syogo").GetComponent<Text>().text = mainSystem.savedata.syogo;
    textObj.transform.Find("level").GetComponent<Text>().text = mainSystem.savedata.level.ToString();
    textObj.transform.Find("startDay").GetComponent<Text>().text = mainSystem.savedata.startTime.ToString();
    textObj.transform.Find("walkDistance").GetComponent<Text>().text = mainSystem.savedata.walkDistance.ToString()+"km";
    textObj.transform.Find("visitedNum").GetComponent<Text>().text = mainSystem.savedata.visitedNum.ToString() + "地点";
    textObj.transform.Find("storyNum").GetComponent<Text>().text = mainSystem.savedata.storyNum.ToString() + "個";
    textObj.transform.Find("monsterNum").GetComponent<Text>().text = mainSystem.savedata.monsterNum.ToString() + "体";
  }

  // Update is called once per frame
  void Update() {

  }
}
