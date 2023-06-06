using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class BulletData
{
    public GameObject prefabObject;
    public Transform prefabTransform; 
}

[Serializable]
public class Bullet
{
    public GameObject bulletReference;
    public RectTransform lodging;
    public List<BulletData> bulletList;

    private int limitCount;
    private const int initPositionX = 0;
    private const int initPositionY = 500;
    private int randomPositionY;

    private GameObject newBullet;
    private BulletData BulletData;

    public void Init(int limitValue)
    {
        limitCount = limitValue;
    }
    public void ShootOutt()
    {
        if (IsOverLimit())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SpawnBullet();
            }
        }
    }
     public void ClearBullet()
    {
        for (int i = 0; i < bulletList.Count; i++)
        {
            if (bulletList[i].prefabTransform.position.x > 1920)
            {
                GameObject.Destroy(bulletList[i].prefabObject);
                bulletList.RemoveAt(i);
            }
        }
    }

    private bool IsOverLimit()
    {
        return bulletList.Count <= limitCount;
    }
    private void SpawnBullet()
    {
        newBullet = GameObject.Instantiate(bulletReference, lodging);
        BulletData = new BulletData
        {
            prefabObject = newBullet,
            prefabTransform = newBullet.GetComponent<Transform>()
        };
        randomPositionY = initPositionY + Random.Range(-450, 450);
        BulletData.prefabTransform.position = new Vector2(initPositionX, randomPositionY);
        bulletList.Add(BulletData);
    }
}

public class Logic : MonoBehaviour
{
    public Bullet Bullet;

    private void Start()
    {
        Bullet.Init(5);
    }
    void Update()
    {
        Bullet.ShootOutt();
        Bullet.ClearBullet();
    }
}
