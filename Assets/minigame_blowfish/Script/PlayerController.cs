using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

  public Vector2 startPos;
  public Vector2 movePos;
  Vector2 worldPos;
  public GameObject[] NPC = new GameObject[6];
  GameObject goNPC;
  GameObject Director;
  ScoreScript scoreScript;
  int i, j, k;
  GameObject moveUI;
  public GameObject MoveUI;
  public GameObject gameoverUI;
  public static bool gameOver;

  // Use this for initialization
  void Start() {
    Director = GameObject.Find("Director");
    scoreScript = Director.GetComponent<ScoreScript>();
    j = scoreScript.i;
    gameOver = false;
  }

  // Update is called once per frame
  void Update() {
    if (!gameOver) {
      if (Input.GetMouseButtonDown(0)) {
        this.startPos = Input.mousePosition;
        moveUI = Instantiate(MoveUI) as GameObject;
        worldPos = Camera.main.ScreenToWorldPoint(startPos);
        moveUI.transform.position = new Vector3(worldPos.x, worldPos.y, 10.0f);
      }
      if (Input.GetMouseButton(0)) {
        this.movePos = Input.mousePosition;
        if (this.movePos.y > this.startPos.y && transform.position.y < 3.8f) {
          transform.Translate(0, 0.1f, 0);
          for (i = 0; i < scoreScript.i; i++) {
            StartCoroutine(DelayMethod(15 * (i + 1), i, 1));
          }
        }
        if (this.movePos.y < this.startPos.y && transform.position.y > -3.8f) {
          transform.Translate(0, -0.1f, 0);
          for (i = 0; i < scoreScript.i; i++) {
            StartCoroutine(DelayMethod(15 * (i + 1), i, -1));
          }
        }

        moveUI.transform.Translate(0.1f + (0.01f * scoreScript.i), 0, 0);
        if (j != scoreScript.i) {
          moveUI.transform.Translate(-0.01f, 0, 0);
          k++;
          if (k == 50) {
            j++;
            k = 0;
          }
        }

      }
      if (Input.GetMouseButtonUp(0)) {
        this.startPos = this.movePos;
        Destroy(moveUI);
      }

      transform.Translate(0.1f + (0.01f * scoreScript.i), 0, 0);
      for (i = 0; i < scoreScript.i; i++) {
        NPC[i].transform.Translate(0.1f + (0.01f * scoreScript.i), 0, 0);
      }
    }
  }

  public void GetNPC() {

    goNPC = Instantiate(NPC[scoreScript.i - 1]) as GameObject;
    goNPC.transform.position = new Vector3(transform.position.x - (1.5f * scoreScript.i), transform.position.y, 0);
    NPC[scoreScript.i - 1] = GameObject.Find("NPC" + scoreScript.i + "(Clone)");

  }

  private IEnumerator DelayMethod(int delayFrame, int a, int x) {
    for (var i = 0; i < delayFrame; i++) {
      yield return null;
    }
    NPC[a].transform.Translate(0, 0.1f * x, 0);

  }

  private void OnTriggerEnter2D(Collider2D collision) {
    if (collision.gameObject.tag == "Finish") {
      Text text=gameoverUI.transform.Find("Text_message").gameObject.GetComponent<Text>();
      string message;

      gameoverUI.SetActive(true);
      message = "Score" +ScoreScript.length+"\n";
      if (ScoreScript.length >= 2000) {
        mainSystem.isGameclear = true;
        message += "ノルマクリア！";
      }
      else {
        message += "ノルマ未達成";
        gameoverUI.transform.Find("Button_restart").gameObject.GetComponent<Button>().interactable = true;
      }
      text.text = message;
      Debug.Log("GameOver");
      gameOver = true;
    }

  }
  public void restart() {
      Application.LoadLevel("blowfishGame"); //再読み込み
  }

}
