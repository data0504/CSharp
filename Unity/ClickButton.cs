using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;


[Serializable]
public class ButtonData
{
    public Button myButton_0; 
    public RectTransform myButton0Rect; 

    public Button myButton_1;
    public RectTransform myButton1Rect;

    public void MonitorButtonEvent()
    {
        myButton_0.onClick.AddListener(ClickUp);
        myButton_1.onClick.AddListener(ClickDown);
    }
    private void ClickUp()
    {
        Debug.Log("Press Up Button");

        (int, int) random = RandomAll();

        myButton_0.gameObject.SetActive(false);
        myButton0Rect.anchoredPosition = new Vector2(random.Item1, random.Item2);
        myButton_1.gameObject.SetActive(true);
    }

    private void ClickDown()
    {
        Debug.Log("Press Down Button");

        (int, int) random = RandomAll();

        myButton_0.gameObject.SetActive(true);
        myButton1Rect.anchoredPosition = new Vector2(random.Item1, random.Item2);
        myButton_1.gameObject.SetActive(false);
    }

    private static (int, int) RandomAll()
    {
        int randomTD = Random.Range(-350, 350);
        int randomLR = Random.Range(-450, 450);
        return (randomLR, randomTD);
    }
}


public class GameLog_01 : MonoBehaviour
{
    public ButtonData buttonData;

    void Start()
    {
        buttonData.MonitorButtonEvent();
    }
    void Update()
    {
        Debug.Log("Not Logic");
    }
}
