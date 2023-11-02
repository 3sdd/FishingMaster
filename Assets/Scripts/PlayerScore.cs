using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int point = 0;

    //public CaughtFishaleObject caughtObjects;

    public bool isActive = true;

    public ScorePoint scoreDisplay;


    public void Add(int point)
    {
        if (!isActive)
            return;
        this.point += point;
        scoreDisplay.UpdateUI(this.point);
    }
}

//[System.Serializable]
//public class CaughtFishaleObject
//{
//    public string name;
//    public int count = 0;
//}
