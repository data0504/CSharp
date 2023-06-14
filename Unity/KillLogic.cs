using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class ParsetData
{
    public RectTransform isObjectRectTransform;
    public Vector2 isWorldPos;
    public Vector2 isWorldSize;

    public float isLeft;
    public float isRight;
    public float isTop;
    public float isBottom;

    public void Init (RectTransform bullerRectTransform)
    {
        isObjectRectTransform = bullerRectTransform;
        isWorldPos = bullerRectTransform.TransformPoint(bullerRectTransform.rect.center);
        isWorldSize = bullerRectTransform.TransformVector(bullerRectTransform.rect.size);

        isLeft = isWorldPos.x - isWorldSize.x / 2;
        isRight = isWorldPos.x + isWorldSize.x / 2;
        isTop = isWorldPos.y + isWorldSize.y / 2;
        isBottom = isWorldPos.y - isWorldSize.y / 2;
    }
}

[Serializable]
public class GameObjectData
{
    public GameObject Obj;
    public RectTransform GameObjectRecTransform;
}

[Serializable]
public class Kill
{ 
    public GameObject BullertPrefab;
    public GameObject BullseyePrefab;
    public RectTransform LoadRectTansform;

    private GameObject newBullertPrefab;
    private GameObject newBullseyePrefab;

    private readonly float setBullertRecTransformAnchoredPositionX = -910f;
    private readonly float setBullseyeRecTransformAbchoredPositionX = 910f;

    private List<GameObjectData> gameObjectBullerDatas;
    private List<GameObjectData> gameObjectBullseyeDatas;
    private List<GameObjectData> indexesToRemove;

    private GameObjectData GameObjectData;
    private ParsetData parsetDataBullert;
    private ParsetData parsetDataBullseys;


    public void Init()
    {
        RandomBullerObjects(BullertPrefab,  LoadRectTansform, setBullertRecTransformAnchoredPositionX);
        RandomBullseyeObjects(BullseyePrefab, LoadRectTansform, setBullseyeRecTransformAbchoredPositionX);
    }
    private void RandomBullerObjects(GameObject initPrefab, RectTransform loadRectTansform, float bullerPointX)
    {
        int RandomObjectNumber = 100;

        gameObjectBullerDatas = new();  
        for (int i = 0; i <= RandomObjectNumber; i++)
        {
            newBullertPrefab = GameObject.Instantiate(initPrefab, loadRectTansform);
            GameObjectData = new()
            {
                Obj = newBullertPrefab,
                GameObjectRecTransform = newBullertPrefab.GetComponent<RectTransform>()
            };

            float RandomPositionY = Random.Range(-490f, 490f);
            GameObjectData.GameObjectRecTransform.anchoredPosition = new Vector2(bullerPointX, RandomPositionY);

            gameObjectBullerDatas.Add(GameObjectData);
        }
    }
    private void RandomBullseyeObjects(GameObject initPrefab, RectTransform loadRectTansform, float bullseyerPointX)
    {
        int RandomObjectNumber = Random.Range(1, 10);

        gameObjectBullseyeDatas = new();        
        for (int i = 0; i <= RandomObjectNumber; i++)
        {

            newBullseyePrefab = GameObject.Instantiate(initPrefab, loadRectTansform);
            GameObjectData = new()
            {
                Obj = newBullseyePrefab,
                GameObjectRecTransform = newBullseyePrefab.GetComponent<RectTransform>()
            };

            float RandomPositionY = Random.Range(-490f, 490f);
            GameObjectData.GameObjectRecTransform.anchoredPosition = new Vector2(bullseyerPointX, RandomPositionY);

            gameObjectBullseyeDatas.Add(GameObjectData);
        }
    }

    public List<GameObjectData> Parser()
    {
        indexesToRemove = new();
        for (int i = gameObjectBullseyeDatas.Count - 1; i >= 0; i--)
        {
            for (int j = gameObjectBullerDatas.Count - 1; j >= 0; j--)
            {
                parsetDataBullert = new();
                parsetDataBullert.Init(gameObjectBullerDatas[j].GameObjectRecTransform);

                parsetDataBullseys = new();
                parsetDataBullseys.Init(gameObjectBullseyeDatas[i].GameObjectRecTransform);

                if (parsetDataBullert.isRight >= parsetDataBullseys.isLeft)
                {
                    if (parsetDataBullert.isTop <= parsetDataBullseys.isTop && parsetDataBullert.isTop >= parsetDataBullseys.isBottom ||
                        parsetDataBullert.isBottom <= parsetDataBullseys.isTop && parsetDataBullert.isTop >= parsetDataBullseys.isBottom)
                    {
                        indexesToRemove.Add(gameObjectBullerDatas[j]);
                        indexesToRemove.Add(gameObjectBullseyeDatas[i]);
                    }
                }
            }
        }
        return indexesToRemove;
    }

    private void DeleteObject(List<GameObjectData> indexesToRemove)
    {
        foreach (var objData in indexesToRemove)
        {
            GameObject.Destroy(objData.Obj);
            gameObjectBullerDatas.Remove(objData);
            gameObjectBullseyeDatas.Remove(objData);
        }
    }

    public void Monitor()
    {
        List<GameObjectData> resolve = Parser();
        DeleteObject(resolve);
    }
}

public class KillLogic : MonoBehaviour
{
    public Kill kill;
    void Start()
    {
        kill.Init();
    }
    void Update()
    { 
        kill.Monitor();
    }
}
