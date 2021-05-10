﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI; 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause(); 
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        //Time.timeScale = 1f;
        GameIsPaused = false;
        AudioListener.pause = false; 
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        //Time.timeScale = 0f;
        GameIsPaused = true;
        AudioListener.pause = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
        //Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene("MainMenu2");
    }

    public void QuitGame()
    {
        Debug.Log("Qutting game...");
        Application.Quit();

    }
}
