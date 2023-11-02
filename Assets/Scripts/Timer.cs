using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public bool isActive = true;
    //秒数
    public int time;

    public SpriteRenderer left;
    public SpriteRenderer right;
    //描画用の0-9のsprite
    public NumberSprite numbers;


    public System.Action OnTimerFinished;

    public int timeLfet;

    private void Awake()
    {
        timeLfet = time;
    }

    private void Start()
    {
        SetUI();
        StartCoroutine(CountDown());

    }

    IEnumerator CountDown()
    {
        while (timeLfet > 0)
        {
            if (!isActive)
            {
                yield return null;
                continue;
            }
            yield return new WaitForSeconds(1);
            timeLfet--;
            SetUI();
        }
        OnTimerFinished?.Invoke();
    }

    void SetUI()
    {
        int leftVal = timeLfet / 10;
        int rightVal = timeLfet % 10;
        left.sprite = numbers.numberSprites[leftVal];
        right.sprite = numbers.numberSprites[rightVal];
    }
}
