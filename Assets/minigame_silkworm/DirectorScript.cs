using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DirectorScript : MonoBehaviour {

  int spawnTime = 0;
  float totalTime;

  public float score = 0;
  public GameObject scoreTextObj;
  public GameObject timeTextObj;

  float x, y;
  GameObject go;
  public GameObject[] leaf = new GameObject[2];

  // Use this for initialization
  void Start() {
    totalTime = 40;
  }

  // Update is called once per frame
  void Update() {
    spawnTime++;
    totalTime -= Time.deltaTime;
    timeTextObj.GetComponent<Text>().text = "time:" + totalTime.ToString("F2");

    //スコア書き換え
    //this.scoreText.GetComponent<Text>().text = this.score.ToString("F0");

    //桑の葉生成
    if (spawnTime == 50) {

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
    if (totalTime<=0) {
      Debug.Log("Finish");
      mainSystem.isGameclear = true;
      Screen.orientation = ScreenOrientation.Portrait;
      SceneManager.LoadScene("minigameMenu");
    }

  }

  public void scoreAdd() {
    this.score++;
    //スコア書き換え
    this.scoreTextObj.GetComponent<Text>().text = "スコア:"+this.score.ToString("F0");
  }

  private void LeafGenereta() {

  }
}
