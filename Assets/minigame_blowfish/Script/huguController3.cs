using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huguController3 : MonoBehaviour
{

    SpriteRenderer huguSpriteRender;
    public Sprite Blowfish2, Blowfish3, Blowfish4, Blowfish5, Blowfish6, Blowfish7,NullSprite;
    int x;
    GameObject Director;
    GameObject[] Blowfish = new GameObject[5];
    huguDirector DirectorScript;
    huguController1 huguScript1;
    huguController2 huguScript2;
    huguController4 huguScript4;
    huguController5 huguScript5;
    huguController6 huguScript6;
    huguGeneratorScript GeneratorScript;

    // Use this for initialization
    void Start()
    {
        huguSpriteRender = gameObject.GetComponent<SpriteRenderer>();

        Director = GameObject.Find("Director");
        DirectorScript = Director.GetComponent<huguDirector>();

        Blowfish[0] = GameObject.Find("Blowfish (1)");
        Blowfish[1] = GameObject.Find("Blowfish (2)");
        Blowfish[2] = GameObject.Find("Blowfish (4)");
        Blowfish[3] = GameObject.Find("Blowfish (5)");
        Blowfish[4] = GameObject.Find("Blowfish (6)");
        huguScript1 = Blowfish[0].GetComponent<huguController1>();
        huguScript2 = Blowfish[1].GetComponent<huguController2>();
        huguScript4 = Blowfish[2].GetComponent<huguController4>();
        huguScript5 = Blowfish[3].GetComponent<huguController5>();
        huguScript6 = Blowfish[4].GetComponent<huguController6>();

        GeneratorScript = Director.GetComponent<huguGeneratorScript>();

    }

    // Update is called once per frame
    void Update()
    {
        x = DirectorScript.i;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        DirectorScript.i++;
        huguScript1.Change();
        huguScript2.Change();
        huguScript4.Change();
        huguScript5.Change();
        huguScript6.Change();
        GeneratorScript.huguAdd();
        huguSpriteRender.sprite = NullSprite;
        Destroy(gameObject.GetComponent<PolygonCollider2D>());
    }
    
    public void Change()
    {
        switch (x+1)
        {
            case 1:
                huguSpriteRender.sprite = Blowfish3;
                break;
            case 2:
                huguSpriteRender.sprite = Blowfish4;
                break;
            case 3:
                huguSpriteRender.sprite = Blowfish5;
                break;
            case 4:
                huguSpriteRender.sprite = Blowfish6;
                break;
            case 5:
                huguSpriteRender.sprite = Blowfish7;
                break;
        }
    }

}