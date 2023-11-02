using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoint : MonoBehaviour
{

    public NumberSprite numbers;
    public SpriteRenderer[] spriteRenderers;//右から

    public void UpdateUI(int num)
    {
        for (int i = spriteRenderers.Length - 1; i >= 0; i--)
        {
            var val = num % 10;

            spriteRenderers[i].sprite = numbers.numberSprites[val];

            num /= 10;
            if (num <= 0)
                break;
        }
    }
}
