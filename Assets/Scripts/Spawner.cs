using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool isActive = true;
    public GameObject[] spawnObjects;

    public float minY;
    public float maxY;

    [Space]
    public float posX;
    [Space]
    public float minInterval;
    public float maxInterval;


    float minZ = -0.1f;
    float maxZ = 0.1f;

    public MoveDirection dir = MoveDirection.Left;


    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            if (!isActive)
            {
                yield return null;
                continue;
            }
            yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));

            var pos = new Vector3(posX, Random.Range(minY, maxY), Random.Range(minZ, maxZ));

            var random = Random.Range(0, spawnObjects.Length);
            var obj = Instantiate(spawnObjects[random], pos, spawnObjects[random].transform.rotation);
            var move = obj.GetComponent<Movement>();
            if (move != null)
            {
                move.direction = dir;
            }
            var f = obj.GetComponent<Fish>();
            if (f != null)
            {
                f.SetDirection(dir);
            }
        }

    }

    private void Update()
    {

    }
}
