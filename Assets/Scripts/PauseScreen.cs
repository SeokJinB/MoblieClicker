using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MainMenu
{
    public static bool paused;
    public GameObject pauseMenu;
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetPauseMenu(bool isPaused)
    {
        paused = isPaused;
        pauseMenu.SetActive(paused);
    }

    void Update()
    {
        Time.timeScale = (paused) ? 0 : 1;
    }
    void Start()
    {
        paused = false;
    }
}
