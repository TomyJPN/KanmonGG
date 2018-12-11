using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafScript : MonoBehaviour {

    GameObject Director;
    DirectorScript directorScript;
  Rigidbody2D rg;

    int deltatime = 0;

	// Use this for initialization
	void Start () {
    rg = this.gameObject.GetComponent<Rigidbody2D>();
    rg.AddTorque(2f, ForceMode2D.Impulse);
    rg.drag = Random.Range(2f,5f);
        Director = GameObject.Find("Director");
        directorScript = Director.GetComponent<DirectorScript>();

	}
	
	// Update is called once per frame
	void Update () {

        this.deltatime++;
        if(deltatime >= 800)
        {
            Destroy(gameObject);
        }
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            directorScript.scoreAdd();
            Destroy(gameObject);
        }
    }
}
