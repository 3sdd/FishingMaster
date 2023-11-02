using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public MoveDirection direction = MoveDirection.Right;
    public float minSpeed = 2;
    public float maxSpeed = 4;

    float speed;
    private void Awake()
    {
        speed = Random.Range(minSpeed, maxSpeed);

    }

    void Update()
    {
        var pos = transform.position + new Vector3(speed * ((int)direction), 0, 0) * Time.deltaTime;


        transform.position = pos;
    }
}


public enum MoveDirection
{
    Left = -1,
    Right = 1,
}