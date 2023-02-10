using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class LevelData
{
    public int currentLevel;
    public int stars;

    public LevelData(Victory victory)
    {
        currentLevel = victory.currentLevel;
        Debug.Log(currentLevel);
        stars = victory.RatingStar();   
    }
}
