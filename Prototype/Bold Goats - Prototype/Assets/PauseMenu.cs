using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject uiForPause;

    [Space]
    public AudioMixer musicVol;
    public Slider musicSlider;
    public AudioMixer sfxVol;
    public Slider sfxSlider;

    private void Awake()
    {
        PlayerPrefs.GetFloat("MusicVolume");
        PlayerPrefs.GetFloat("SFXVolume");
    }

    // Update is called once per frame
    void Update()
    {
        SetMusicVolume(musicSlider.value);
        SetSFXVolume(sfxSlider.value);



        if (uiForPause != null)
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
    }

    public void Resume()
    {
        if (uiForPause != null)
        {
        uiForPause.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        }
    }

    void Pause()
    {
        if (uiForPause != null)
        {
        uiForPause.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        }
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

    public void SetMusicVolume(float _volume)
    {
        musicVol.SetFloat("MusicVol", _volume);
    }

    public void SetSFXVolume(float _volume)
    {
        sfxVol.SetFloat("SFXVol", _volume);
    }

    void PlayerSettings()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
    }

    public void Quit()
    {

    }
}
