using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DirectorScript : MonoBehaviour {

  int spawnTime = 0;
  public float totalTime;

  public float score = 0;
  public GameObject scoreTextObj;
  public GameObject timeTextObj;
  public GameObject resultObj;

  public static bool isEnd;

  float x, y;
  GameObject go;
  public GameObject[] leaf = new GameObject[2];

  // Use this for initialization
  void Start() {
    //totalTime = 40;
    isEnd = false;
  }

  // Update is called once per frame
  void Update() {
    if (!isEnd) {
      spawnTime++;
      totalTime -= Time.deltaTime;
    }
    else {
      totalTime = 0;
    }
      timeTextObj.GetComponent<Text>().text = "time:" + totalTime.ToString("F2");
    //スコア書き換え
    //this.scoreText.GetComponent<Text>().text = this.score.ToString("F0");

    //桑の葉生成
    if (spawnTime == 50 && !isEnd) {

      int i = Random.Range(0, 2);
      this.go = Instantiate(leaf[i]) as GameObject;

      this.x = Random.Range(-7, 7);
      this.y = 7;
      this.go.transform.position = new Vector3(this.x, this.y, 0);

      this.x = Random.Range(-1, 1);
      if (this.x == 0) {
        this.x = 1;
      }
      this.y = Random.Range(-1, 1);
      if (this.y == 0) {
        this.y = 1;
      }
      this.go.transform.localScale = new Vector3(this.x * 0.5f, this.y * 0.5f, 0);

      this.spawnTime = 0;
    }

    //40秒で終了の条件分岐
    if (totalTime<=0 && !isEnd) {
      isEnd = true;
      resultObj.SetActive(true);
      if (score >= 50) {
        mainSystem.isGameclear = true;
        resultObj.transform.Find("Text_message").transform.GetComponent<Text>().text = "Score:" + score.ToString() + "\nノルマクリア！";
      }
      else {
        resultObj.transform.Find("Text_message").transform.GetComponent<Text>().text = "Score:" + score.ToString() + "\nノルマ未達成";
        resultObj.transform.Find("Button_restart").transform.GetComponent<Button>().interactable = true;
      }
    }

  }

  public void scoreAdd() {
    this.score++;
    //スコア書き換え
    this.scoreTextObj.GetComponent<Text>().text = "スコア:"+this.score.ToString("F0");
  }
  public void restart() {
    Application.LoadLevel("silkwormGame"); //再読み込み
  }
  public void endGame() {
    Screen.orientation = ScreenOrientation.Portrait;
    SceneManager.LoadScene("minigameMenu");
  }
}
