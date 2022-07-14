using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StarManager : MonoBehaviour
{
    [SerializeField] private UI_LoadLevelStar[] level;

    private List<LevelData> levelDataList;

    private void Awake()
    {
        level = GetComponentsInChildren<UI_LoadLevelStar>(); 
    }

    private void Start()
    {
        levelDataList = LevelManager.Instance.GetLevelDataList();
        UpdateStarUI();
    }

    private void UpdateStarUI()
    {
        if (levelDataList == null)
        {
            Debug.Log("level data list is null");
        } else
        {
            for (int i = 0; i < levelDataList.Count; i++)
            {
                level[i].collectedStar = levelDataList[i].colectedStars;
            }    
        }
    }
}
