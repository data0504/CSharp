using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;



public class ButterflyLogic : MonoBehaviour
{
    public GameObject View_bullet;
    public RectTransform  View_bulletRect;

    private readonly float pointX = 50f;
    private readonly float pointY = 500f;
    private readonly float pointZ = 0f;
    private readonly float addPointX = 5f;

    private float row = 1f;


    private GameObject Model_bullet;
    private Transform Model_bullet_Transfrom;



    void Start()
    {
        Model_bullet = Instantiate(View_bullet, View_bulletRect);
        Model_bullet_Transfrom = Model_bullet.GetComponent<Transform>();
        InvokeRepeating(nameof(Fly), 0.0000001f, 0.075f);
    }
    private void Fly()
    {
        float pointXIng = pointX + (row += addPointX);
        float pointYIng = pointY + Random.Range(-350f, 350f);
        Model_bullet_Transfrom.position = new Vector3(pointXIng, pointYIng, pointZ);
    }

    void Update()
    {
        //not logic
    }

}
