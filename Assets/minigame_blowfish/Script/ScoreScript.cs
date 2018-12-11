using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    GameObject player;
    GameObject score;
    public int i = 0;
    public static int length;

	// Use this for initialization
	void Start () {

        this.player = GameObject.Find("Blowfish1");
        this.score = GameObject.Find("Score");
	}
	
	// Update is called once per frame
	void Update () {

            length = (((int)this.player.transform.position.x + 7) * (i + 1));
            
            this.score.GetComponent<Text>().text = "スコア:" + length.ToString("D4");
	}
}
