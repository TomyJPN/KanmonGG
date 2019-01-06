using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class profile_activity : MonoBehaviour {
  public GameObject textObj;

  // Use this for initialization
  void Start() {
    textObj.transform.Find("name").GetComponent<Text>().text = saveLoad.saveData.name;
    textObj.transform.Find("syogo").GetComponent<Text>().text = saveLoad.saveData.syogo;
    textObj.transform.Find("level").GetComponent<Text>().text = saveLoad.saveData.level.ToString();
    textObj.transform.Find("startDay").GetComponent<Text>().text = saveLoad.saveData.startTime.ToString();
    textObj.transform.Find("walkDistance").GetComponent<Text>().text = saveLoad.saveData.walkDistance.ToString()+"km";
    textObj.transform.Find("visitedNum").GetComponent<Text>().text = saveLoad.saveData.visitedNum.ToString() + "地点";
    textObj.transform.Find("storyNum").GetComponent<Text>().text = saveLoad.saveData.storyNum.ToString() + "個";
    textObj.transform.Find("monsterNum").GetComponent<Text>().text = saveLoad.saveData.monsterNum.ToString() + "体";
  }

  // Update is called once per frame
  void Update() {

  }
}
