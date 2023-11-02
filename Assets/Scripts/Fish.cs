using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : FishableObject
{
    //public float speed = 4;

    SpriteRenderer spriteRenderer;
    public MoveDirection direction = MoveDirection.Left;

    public bool isBiting = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        if (isBiting)
        {
            return;
        }
    }

    public void SetDirection(MoveDirection dir)
    {
        direction = dir;
        if (direction == MoveDirection.Left)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }
}

public enum FishDirection
{
    Left = -1,
    Right = 1,
}