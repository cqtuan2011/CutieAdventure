using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelData
{
    public int levelIndex;
    public int colectedStars;
    
    public LevelData() // Create empty levelData from start
    {

    }

    public void UpdateData(LevelData levelData)
    {
        this.levelIndex = levelData.levelIndex;

        if (this.colectedStars < levelData.colectedStars)
        {
            this.colectedStars = levelData.colectedStars;
        }
        else return;

    }
}


