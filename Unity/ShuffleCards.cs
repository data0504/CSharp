using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardManager : MonoBehaviour
{
    public GameObject cardPrefab;   // 牌的預製體，可以在Unity編輯器中指定
    public Sprite cardBack;         // 牌的背面圖片，可以在Unity編輯器中指定
    public List<Sprite> cardFaces;  // 牌的正面圖片列表，可以在Unity編輯器中指定

    private List<GameObject> cards = new List<GameObject>(); // 牌的列表

    private void Start()
    {
        ShuffleCards(); // 遊戲開始時洗牌
    }

    private void CreateCards()
    {
        // 創建52張牌的遊戲物體
        for (int i = 0; i < 52; i++)
        {
            GameObject card = Instantiate(cardPrefab, transform);
            card.GetComponent<Card>().SetCardImages(cardBack, cardFaces[i]);
            cards.Add(card);
        }
    }
    private void ShuffleMode()
    {
        // 洗牌算法
        for (int i = 0; i < cards.Count; i++)
        {
            GameObject temp = cards[i];
            int randomIndex = Random.Range(i, cards.Count);
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }

    }

    private void ViewCards()
    {

        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].transform.position = new Vector3(i * 2.0f, 0f, 0f);
        }
    }


    public void ShuffleCards()
    {
        CreateCards(); // 創建牌

        ShuffleMode(); // 洗牌模型

        ViewCards(); // 更新牌的位置

    }

    public void FlipCards()
    {
        foreach (GameObject card in cards)
        {
            card.GetComponent<Card>().Flip();
        }
    }
}
