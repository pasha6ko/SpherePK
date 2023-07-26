using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartsRender : MonoBehaviour
{
    [SerializeField] private Image stars;
    public float maxScore, score;
    private void Start()
    {
    }
    public void UpdateStars()
    {
        if(score<0) stars.enabled = false;
        stars.fillAmount = ((float)Mathf.FloorToInt((score / maxScore) * 3)) / 3f;
    }
}
