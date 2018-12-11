using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGeneretator : MonoBehaviour {

    public GameObject[] rock = new GameObject[16];
    public GameObject fish;
    GameObject go;
    GameObject gofish;
    Vector3 hozon;
    int a, i, j, l, r, count = 1, beforerock, hugucount = 100;
    float x, y;
    float movelength;
    GameObject player;
    GameObject Director;
    ScoreScript scoreScript;

	// Use this for initialization
	void Start () {

        player = GameObject.Find("Blowfish1");

        hozon = new Vector3(4.0f, 0, 0);
        j = Random.Range(0, 2);

        Director = GameObject.Find("Director");
        scoreScript = Director.GetComponent<ScoreScript>();

        //最初は岩を15個配置
        for (a = 1; a <= 15; a++) {

            //岩の出現を上下交互に
            switch (j)
            {
                case 0:
                    y = 1.0f;
                    i = Random.Range(8, 16);
                    if ((beforerock == 4 || beforerock == 5) && (i == 12 || i == 13))
                    {
                        i = Random.Range(6, 12);
                        switch (i)
                        {
                            case 6:
                                i = 14;
                                break;
                            case 7:
                                i = 15;
                                break;
                        }
                    }
                    j = 1;
                    break;
                case 1:
                    y = -1.0f;
                    i = Random.Range(0, 8);
                    if ((beforerock == 12 || beforerock == 13) && (i == 4 || i == 5))
                    {
                        i = Random.Range(-2, 4);
                        switch (i)
                        {
                            case -1:
                                i = 6;
                                break;
                            case -2:
                                i = 7;
                                break;
                        }
                    }
                    j = 0;
                    break;
            }

            //少しずつ難しく
            if (count <= 67)
            {
                count++;
            }
            x = Random.Range(count, count + 33);
            if (1 <= x && x <= 33)
            {
                x = 10;
            }
            else if (34 <= x && x <= 66)
            {
                x = 8;
            }
            else if (67 <= x)
            {
                x = 6;
            }

            go = Instantiate(rock[i]) as GameObject;
            go.transform.position = new Vector3(hozon.x + x, y, 0);

            //岩を保存
            beforerock = i;
            if (hugucount > 3 && scoreScript.i <= 5)
            {
                //フグを生成
                r = Random.Range(1, 6);
                if (r == 1)
                {
                    hugucount = 0;
                    gofish = Instantiate(fish) as GameObject;
                    gofish.transform.position = new Vector3(hozon.x + x, -y * 4, 0);
                }
            }

            hozon = go.transform.position;
        }
	}
	
	// Update is called once per frame
	void Update () {

        movelength = hozon.x - player.transform.position.x;

        if (movelength < 30.0f)
        {
            x = Random.Range(7, 10);
            hugucount++;

            //岩の出現を上下交互に
            switch (j)
            {
                case 0:
                    y = 1.0f;
                    i = Random.Range(8, 16);
                    if ((beforerock == 4 || beforerock == 5) && (i == 12 || i == 13))
                    {
                        i = Random.Range(6, 12);
                        switch (i)
                        {
                            case 6:
                                i = 14;
                                break;
                            case 7:
                                i = 15;
                                break;
                            default:
                                break;
                        }
                    }
                    j = 1;
                    break;
                case 1:
                    y = -1.0f;
                    i = Random.Range(0, 8);
                    if ((beforerock == 12 || beforerock == 13) && (i == 4 || i == 5))
                    {
                        i = Random.Range(-2, 4);
                        switch (i)
                        {
                            case -1:
                                i = 6;
                                break;
                            case -2:
                                i = 7;
                                break;
                            default:
                                break;
                        }
                    }
                    j = 0;
                    break;
            }

            //少しずつ難しく
            if (count <= 67)
            {
                count++;
            }
            x = Random.Range(count, count + 33);
            if (1 <= x && x <= 333)
            {
                x = 10;
            }
            else if (34 <= x && x <= 66)
            {
                x = 8;
            }
            else if (67 <= x)
            {
                x = 6;
            }

            go = Instantiate(rock[i]) as GameObject;
            go.transform.position = new Vector3(hozon.x + x, y, 0);

            //前の岩のデータを保存。次の時に悪い組み合わせが来るのを防ぐ。
            beforerock = i;

            if (hugucount > 3 && scoreScript.i <= 5)
            {
                //フグを生成。
                r = Random.Range(1, 6);
                if (r == 1)
                {
                    hugucount = 0;
                    gofish = Instantiate(fish) as GameObject;
                    gofish.transform.position = new Vector3(hozon.x + x, -y * 4, 0);
                }
            }

            hozon = go.transform.position;

            a++;
        }
    }
}
