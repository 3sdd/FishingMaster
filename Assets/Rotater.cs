using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public RotationDir rotationDir = RotationDir.Clockwise;
    public float rotationSpeed;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * ((int)(rotationDir)) * Time.deltaTime), Space.World);
    }
}

public enum RotationDir
{
    Clockwise = 1,
    CounterClockwise = -1,
}
