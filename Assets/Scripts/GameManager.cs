using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public float spawnRate = 0.5f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public PauseScreen pauseScreen;
    public GameObject restartButton;
    private int score;
    public float time;
    public bool isGameActive;

    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseScreen.SetPauseMenu(true);
        }

        if (time < 0)
        {
            GameOver();
        }
        else
            UpdateTime();

        Time.timeScale = (!isGameActive) ? 0 : 1;
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }
    
    void UpdateTime()
    {
        time -= Time.deltaTime;
        timerText.text = "Time : " + (int)time;
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    void GameOver()
    {
        isGameActive = false;
        timerText.text = "Time : 0";
        restartButton.SetActive(true);
    }
}
