using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float minX;
    public float maxX;

    public float speed = 5;

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");

        var pos = transform.position + new Vector3(horizontal * speed, 0, 0) * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);

        transform.position = pos;

    }

}
