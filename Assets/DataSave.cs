using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataSave : MonoBehaviour
{
    [SerializeField] public List<LevelLoadButton> levelLoadButtons = new List<LevelLoadButton>();
    Dictionary<string, Dictionary<string, float>> mapData = new Dictionary<string, Dictionary<string, float>>();
    [SerializeField] bool loadAfterStart;
    private void Start()
    {
        if(loadAfterStart)LoadMapData();
    }
    public void SaveCurrentLevelScore()
    {
        PlayerPrefs.SetFloat($"{SceneManager.GetActiveScene().name}/score", GameResources.instance.currentLevelScore);
        PlayerPrefs.SetFloat($"{SceneManager.GetActiveScene().name}/maxScore", GameResources.instance.maxLevelScore);
        PlayerPrefs.Save();

    }
    public void LoadMapData()
    {

        foreach (LevelLoadButton level in levelLoadButtons)
        {
            float score = PlayerPrefs.GetFloat($"{level.sceneToLoadName}/score", -1f);
            float maxScore =  PlayerPrefs.GetFloat($"{level.sceneToLoadName}/maxScore", -1f);
            print($"{score}, {maxScore}");
            if (!mapData.ContainsKey(level.sceneToLoadName)) mapData.Add(level.sceneToLoadName, new Dictionary<string, float>() { { $"score", score }, { $"maxScore", maxScore } });
            else
            {
                mapData[level.sceneToLoadName] = new Dictionary<string, float>() { { $"score", score }, { $"maxScore", maxScore } };
            }
        }
        SetUpStars();
    }
    public void SetUpStars()
    {
        foreach (LevelLoadButton level in levelLoadButtons)
        {
            level.starts.score = mapData[level.sceneToLoadName]["score"];
            level.starts.maxScore = mapData[level.sceneToLoadName]["maxScore"];
            level.starts.UpdateStars();
        }
    }
    public void Restart()
    {
        PlayerPrefs.DeleteAll();
        LoadMapData();
    }
}
