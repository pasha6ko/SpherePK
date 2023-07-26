using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class GameResources : MonoBehaviour
{
    public static GameResources instance { get; private set; }
    [SerializeField] StartsRender starts;
    [SerializeField] private Slider gameScoreSlider,menuScoreSlider;
    public float maxLevelScore = 0f;
    [SerializeField]TMPro.TextMeshProUGUI gameScoreText,menuScoreText;
    public float currentLevelScore=0f;
    //static public Action UIAction;
    public List<Pig> pigs;

    private void Awake()
    {
         if (instance != null && instance != this)
        {
            print("destroy");
            Destroy(this);
        }
        else instance = this;
        print(instance.gameObject.name);
    }
    private void Start()
    {
        
        gameScoreSlider.maxValue = maxLevelScore;
        menuScoreSlider.maxValue = maxLevelScore;
    }
    private void UpdateUI()
    {
        gameScoreSlider.value = currentLevelScore;
        gameScoreText.text = ((int)currentLevelScore).ToString();
        menuScoreText.text = ((int)currentLevelScore).ToString();
    }
    public void PlusScore(float value)
    {
        currentLevelScore += value;
        starts.score = currentLevelScore;
        UpdateUI();
        starts.UpdateStars();
    }
    public void SetMaxLevelScore(float value)
    {
        maxLevelScore += value;
        starts.maxScore = maxLevelScore;
        UpdateUI();

    }
    public void AddPig(Pig pig)
    {
        pigs.Add(pig);
        starts.UpdateStars();

    }
    public void RemovePig(Pig pig)
    {
        UpdateUI();
        starts.UpdateStars();

        pigs.Remove(pig);
        print("removePig");
        if (pigs.Count > 0) return;
        print("End");
        StartCoroutine(TimeEvents.WaitTilDo(4f, SceneEvents.instance.EndGame));
    }

}
