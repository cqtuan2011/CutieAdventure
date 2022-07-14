using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField] private int totalLevel = 5;

    private List<LevelData> levelDataList;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        levelDataList = new List<LevelData>();

        if (PlayerPrefs.GetString("LevelData") == string.Empty)
        {
            for (int i = 0; i < totalLevel; i++)
            {
                var newLevelData = new LevelData() { levelIndex = i + 1 };
                levelDataList.Add(newLevelData);
            }
        } else
        {
            var savedData = PlayerPrefs.GetString("LevelData");

            var newListData = JsonConvert.DeserializeObject<List<LevelData>>(savedData);

            levelDataList = newListData;
        }
    }

    public List<LevelData> GetLevelDataList()
    {
        return levelDataList;
    }

    public void UpdateLevelData(LevelData levelData)
    {
        var newData = levelDataList.Find(x => x.levelIndex == levelData.levelIndex);
        newData.UpdateData(levelData);

        var json = JsonConvert.SerializeObject(levelDataList);
        
        PlayerPrefs.SetString("LevelData", json);
    }
}
