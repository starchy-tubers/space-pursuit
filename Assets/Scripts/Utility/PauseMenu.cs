﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    public static bool muted = false;
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void MainMenu()
    {
        Resume();
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void Mute()
    {
        if (muted == false)
        {
            AudioListener.pause = true;
            muted = true;
        }
        else
        {
            AudioListener.pause = false;
            muted = false;
        }
    }
}