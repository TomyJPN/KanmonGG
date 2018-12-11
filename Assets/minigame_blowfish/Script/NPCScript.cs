using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour {

    GameObject Director;
    ScoreScript ScoreScript;
    SpriteRenderer NPCSpriteRenderer;
    public Sprite[] NPCSprite = new Sprite[5];
    int x;
    GameObject player;
    PlayerController playerScript;

	// Use this for initialization
	void Start () {
        NPCSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        Director = GameObject.Find("Director");
        ScoreScript = Director.GetComponent<ScoreScript>();

        player = GameObject.Find("Blowfish1");
        playerScript = player.GetComponent<PlayerController>();

        if (ScoreScript.i != 0)
        {
            x = ScoreScript.i;
            NPCSpriteRenderer.sprite = NPCSprite[ScoreScript.i - 1];
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (ScoreScript.i >= 6)
        {
            Destroy(gameObject);
        }
        else if (ScoreScript.i != x && ScoreScript.i<= 5)
        {
            x = ScoreScript.i;
            NPCSpriteRenderer.sprite = NPCSprite[ScoreScript.i - 1];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreScript.i++;
        playerScript.GetNPC();
        Destroy(gameObject);
    }
}
