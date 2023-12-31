using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEvents : MonoBehaviour
{
    [SerializeField] Animator pauseAnimator;
    [SerializeField] GameObject endGameMenu,gameMenu;
    [SerializeField] BirdGrab BirdGrab;
    [SerializeField] DataSave dataSave;
    public static SceneEvents instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this) Destroy(this);
        else instance = this;
    }
    public void PauseGame()
    {
        pauseAnimator.Play("PauseGame");
    }
    public void Resume()
    {
        
        pauseAnimator.Play("ResumeGame");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndGame()
    {
        dataSave.SaveCurrentLevelScore();
        BirdGrab.enabled = false;
        endGameMenu.SetActive(true);
        gameMenu.SetActive(false);
    }
    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}