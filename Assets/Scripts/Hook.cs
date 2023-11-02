using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public float catchPositionY;
    public PlayerScore playerScore;

    public AudioSource getGoodItemSound;
    public AudioSource getBadItemSound;

    //釣り針にかかっている
    FishableObject fishableObject;

    private void Update()
    {
        if (fishableObject != null)
        {
            fishableObject.transform.position = transform.position;
        }

        if (transform.position.y > catchPositionY)
        {
            GetFishableObject();
        }
    }

    void GetFishableObject()
    {
        if (fishableObject != null)
        {
            var point = fishableObject.GetComponent<Point>();
            float pointToAdd = 0;
            if (point != null)
            {
                pointToAdd = point.point;
                playerScore.Add(point.point);

            }

            if (pointToAdd >= 0)
            {
                if (getGoodItemSound != null)
                {
                    getGoodItemSound.Play();
                }
            }
            else
            {
                if (getBadItemSound != null)
                {
                    getBadItemSound.Play();
                }
            }

            Destroy(fishableObject.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var t = collision.GetComponent<FishableObject>();
        if (t != null)
        {
            fishableObject = t;
        }
    }
}
