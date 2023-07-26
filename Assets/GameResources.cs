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
    private float _maxLevelScore = 0f;
    [SerializeField]TMPro.TextMeshProUGUI gameScoreText,menuScoreText;
    private float _currentLevelScore=0f;
    static public Action UIAction;
    public List<Pig> pigs;
    private void Awake()
    {
        if (instance != null && instance != this) Destroy(this);
        else instance = this;
        GameResources.UIAction += this.UpdateUI;
        GameResources.UIAction += starts.UpdateStars;
    }
    private void Start()
    {
        gameScoreSlider.maxValue = _maxLevelScore;
        menuScoreSlider.maxValue = _maxLevelScore;
    }
    private void UpdateUI()
    {
        gameScoreSlider.value = _currentLevelScore;
        gameScoreText.text = ((int)_currentLevelScore).ToString();
        menuScoreText.text = ((int)_currentLevelScore).ToString();
    }
    public void PlusScore(float value)
    {
        _currentLevelScore += value;
        starts.score = _currentLevelScore;
        GameResources.UIAction.Invoke();
    }
    public void SetMaxLevelScore(float value)
    {
        _maxLevelScore += value;
        starts.maxScore = _maxLevelScore;
        GameResources.UIAction.Invoke(); 
    }
    public void AddPig(Pig pig)
    {
        pigs.Add(pig);
    }
    public void RemovePig(Pig pig)
    {
        GameResources.UIAction.Invoke();
        pigs.Remove(pig);
        print("removePig");
        if (pigs.Count > 0) return;
        print("End");
        StartCoroutine(TimeEvents.WaitTilDo(4f, SceneEvents.instance.EndGame));
    }

}
