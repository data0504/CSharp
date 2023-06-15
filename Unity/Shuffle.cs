using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShuffleData
{
    private GameObject cardContainer;
    private SpriteRenderer[] cardRenderers;
    public void Init(GameObject container, SpriteRenderer[] renderers)
    {
        cardContainer = container;
        cardRenderers = renderers;
        GetCardRenderers();
    }
    public void ClickMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Left Button");
            ShuffleCards();
        }
    }
    private void GetCardRenderers()
    {
        cardRenderers = cardContainer.GetComponentsInChildren<SpriteRenderer>();
    }

    private void ShuffleCards()
    {
        System.Random random = new();
        for (int i = cardRenderers.Length - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            Sprite temp = cardRenderers[i].sprite;
            cardRenderers[i].sprite = cardRenderers[j].sprite;
            cardRenderers[j].sprite = temp;
        }
    }

}

public class Shuffle : MonoBehaviour
{
    readonly ShuffleData shuffleData = new();
    public GameObject container; 
    private readonly SpriteRenderer[] renderers; 

    void Start()
    {
        shuffleData.Init(container, renderers);
    }

    void Update()
    {
        shuffleData.ClickMouse();
    }
}
