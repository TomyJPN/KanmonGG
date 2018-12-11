using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_silk : MonoBehaviour {

    Vector3 startPos, endPos;
    float deltax, deltay, deltaxy;

    GameObject Director;
    DirectorScript directorScript;

	// Use this for initialization
	void Start () {
        startPos = transform.position;

        this.Director = GameObject.Find("Director");
        this.directorScript = Director.GetComponent<DirectorScript>();
	}
	
	// Update is called once per frame
	void Update () {

        //Player移動
        if (Input.GetMouseButton(0))
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            startPos = transform.position;

            deltax = endPos.x - startPos.x;
            deltay = endPos.y - startPos.y;

            deltaxy = Mathf.Sqrt((deltax * deltax) + (deltay * deltay));

            if (Mathf.Abs(deltax) >= 0.05f && Mathf.Abs(deltay) >= 0.05f)
            {

                //Debug.Log(deltaxy);

                if (deltaxy <= 10.0f)
                {
                    deltaxy = deltaxy * 1.3f;
                }

                transform.Translate((0.1f * deltax / deltaxy), (0.1f * deltay / deltaxy), 0);
            }
            else if(Mathf.Abs(deltax) >= 0.01f && Mathf.Abs(deltay) >= 0.01f)
            {
                transform.Translate((0.05f * deltax / deltaxy), (0.05f * deltay / deltaxy), 0);
            }
        }

        //大きさ調整

        this.transform.localScale = new Vector3(1 + (directorScript.score / 40), 1 + (directorScript.score / 40), 0);
    }
}
