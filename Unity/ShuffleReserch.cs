using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[Serializable]
public class ShuffleData
{
    public GameObject Objectprefab;
    public RectTransform loadGroups;
    public Sprite[] cardsListsPrefab;

    private static readonly List<GameObject> gameObjects = new();

    private void AddImage(int i, GameObject cardObject)
    {
        Image spriteRenderer = cardObject.GetComponent<Image>();
        spriteRenderer.sprite = cardsListsPrefab[i];
    }

    private GameObject CreateObject(int i)
    {
        GameObject cardObject = GameObject.Instantiate(Objectprefab, loadGroups);
        cardObject.name = $"Card{i}";
        return cardObject;
    }
    public void InitCardPrefab()
    {
        for (int i = 0; i < cardsListsPrefab.Length; i++)
        {
            GameObject cardObject = CreateObject(i);

            AddImage(i, cardObject);

            gameObjects.Add(cardObject);
        }
    }
    public void RandomSort()
    {
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < cardsListsPrefab.Length; i++)
            {
                gameObjects[i].transform.SetSiblingIndex(Random.Range(0, 52));
            }
        }
    }
}
public class ShuffleReserch : MonoBehaviour
{
    public ShuffleData shuffleData;
    void Start()
    {
        shuffleData.InitCardPrefab();
    }
    void Update()
    {
        shuffleData.RandomSort();
    }
}
