using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject uiForPause;

    void Start()
    {
        resolutions = Screen.resolutions;

        resDropdown.ClearOptions();

        List<string> res = new List<string>();

        int currentRes = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string tempRes = resolutions[i].width + " x " + resolutions[i].height + " : " + resolutions[i].refreshRate;
            res.Add(tempRes);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentRes = i;
            }
        }

        resDropdown.AddOptions(res);

        resDropdown.value = currentRes;
        resDropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && uiForPause != null)
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
        SceneManager.LoadScene("Main Menu");
    }

    // Graphic Settings

    Resolution[] resolutions;
    public TMPro.TMP_Dropdown resDropdown;

    public void ToggleFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }


    public void SetRes(int _resIndex)
    {
        Resolution resolution = resolutions[_resIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // Sound Settings

    public AudioMixer musicMixer;
    public AudioMixer sfxMixer;

    public void SetMusicVolume(float _volume)
    {
        musicMixer.SetFloat("MusicVolume", _volume);
    }

    public void SetSFXVolume(float _volume)
    {
        sfxMixer.SetFloat("SFXVolume", _volume);
    }

}
