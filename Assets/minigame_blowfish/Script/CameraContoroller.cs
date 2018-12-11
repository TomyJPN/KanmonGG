using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoroller : MonoBehaviour {

    GameObject Director;
    ScoreScript scoreScript;
    int i = 0, j;

    // Use this for initialization
    void Start () {

        Director = GameObject.Find("Director");
        scoreScript = Director.GetComponent<ScoreScript>();
        j = scoreScript.i;
    }
	
	// Update is called once per frame
	void Update () {
        
        transform.Translate(0.1f + (0.01f * scoreScript.i), 0, 0);
        if (j != scoreScript.i)
        {
            transform.Translate(-0.03f, 0, 0);
            i++;
            if (i == 50)
            {
                j++;
                i = 0;
            }
        }
	}
}
