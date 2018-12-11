using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DirectorScript : MonoBehaviour {

  int deltatime = 0;

  public float score = 0;
  GameObject scoreText;

  float x, y;
  GameObject go;
  public GameObject[] leaf = new GameObject[2];

  int time = 0;

  // Use this for initialization
  void Start() {
    this.scoreText = GameObject.Find("Score");
  }

  // Update is called once per frame
  void Update() {
    this.deltatime++;

    //スコア書き換え
    //this.scoreText.GetComponent<Text>().text = this.score.ToString("F0");

    //桑の葉生成
    if (deltatime == 50) {

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

      this.deltatime = 0;
    }

    //60秒で終了の条件分岐
    this.time++;
    if (this.time >= 3600) {
      Debug.Log("Finish");
      mainSystem.isGameclear = true;
      Screen.orientation = ScreenOrientation.Portrait;
      SceneManager.LoadScene("minigameMenu");
    }

  }

  public void scoreAdd() {
    this.score++;
    //スコア書き換え
    this.scoreText.GetComponent<Text>().text = this.score.ToString("F0");
  }

  private void LeafGenereta() {

  }
}
