using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Butterfly
{

    private readonly float pointX = 50f;
    private readonly float pointY = 500f;
    private readonly float pointZ = 0f;
    private readonly float addPointX = 5f;

    private float row = 1f;
    private float timer = 0f;
    private readonly float interval = 0.075f;
    private float timeGap;


    private GameObject Model_bullet;
    private Transform Model_bullet_Transfrom;


    public void Init(GameObject view_bullet, RectTransform view_bulletRect)
    {
        Model_bullet = GameObject.Instantiate(view_bullet, view_bulletRect);
        Model_bullet_Transfrom = Model_bullet.GetComponent<Transform>();
    }
    private void Fly()
    {
        float pointXIng = pointX + (row += addPointX);
        float pointYIng = pointY + Random.Range(-350f, 350f);
        Model_bullet_Transfrom.position = new Vector3(pointXIng, pointYIng, pointZ);
    }

    public void ParserTime(float deltaTime)
    {
        timer += deltaTime;
        if (timer >= interval)
        {
            Fly();
            timeGap = interval - timer;
            timer = timeGap;
        }
    }
}

public class ButterflyLogic : MonoBehaviour
{
    public GameObject View_bullet; 
    public RectTransform View_bulletRect; 
    readonly Butterfly butterfly = new();

    void Start()
    {
        butterfly.Init(View_bullet, View_bulletRect);
    }

    void Update()
    {
        butterfly.ParserTime(Time.deltaTime);
    }
}
