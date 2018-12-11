using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huguGeneratorScript : MonoBehaviour {

    GameObject Director;
    huguDirector DirectorScript;

    GameObject player;

    public GameObject[] BlowfishPrefab = new GameObject[6];


	// Use this for initialization
	void Start () {

        Director = GameObject.Find("Director");
        DirectorScript = Director.GetComponent<huguDirector>();

        player = GameObject.Find("Blowfish1");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void huguAdd()
    {
        switch (DirectorScript.i)
        {
            case 1:
                GameObject Blowfish2 = Instantiate(BlowfishPrefab[0]) as GameObject;
                Blowfish2.transform.position = new Vector3(player.transform.position.x - 1.6f, player.transform.position.y, 0);
                break;
            case 2:
                GameObject Blowfish3 = Instantiate(BlowfishPrefab[1]) as GameObject;
                Blowfish3.transform.position = new Vector3(player.transform.position.x - 3.2f, player.transform.position.y, 0);
                break;
            case 3:
                GameObject Blowfish4 = Instantiate(BlowfishPrefab[2]) as GameObject;
                Blowfish4.transform.position = new Vector3(player.transform.position.x - 4.8f, player.transform.position.y, 0);
                break;
            case 4:
                GameObject Blowfish5 = Instantiate(BlowfishPrefab[3]) as GameObject;
                Blowfish5.transform.position = new Vector3(player.transform.position.x - 6.4f, player.transform.position.y, 0);
                break;
            case 5:
                GameObject Blowfish6 = Instantiate(BlowfishPrefab[4]) as GameObject;
                Blowfish6.transform.position = new Vector3(player.transform.position.x - 8.0f, player.transform.position.y, 0);
                break;
            case 6:
                GameObject Blowfish7 = Instantiate(BlowfishPrefab[5]) as GameObject;
                Blowfish7.transform.position = new Vector3(player.transform.position.x - 9.6f, player.transform.position.y, 0);
                break;

        }
    }
}
