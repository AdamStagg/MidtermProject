using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject uiForPause;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        uiForPause.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        uiForPause.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Options()
    {

    }

    public void Save()
    {

    }

    public void LoadSave()
    {

    }

    public void Quit()
    {

    }
}
