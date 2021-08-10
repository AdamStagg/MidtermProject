using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsSettings : MonoBehaviour
{
    Resolution[] resolutions;
    public TMPro.TMP_Dropdown resDropdown;
    private int fsBool = 0;

    private void Awake()
    {
        PlayerPrefs.GetInt("Is FullScreen");
    }
    public void ToggleFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        if (isFullscreen)
        {
            fsBool = 1;
        }
        else
        {
            fsBool = 0;
        }
    }

    void Start()
    {
        resolutions = Screen.resolutions;

        resDropdown.ClearOptions();

        List<string> res = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string tempRes = resolutions[i].width + " x " + resolutions[i].height;
            res.Add(tempRes);
        }

        resDropdown.AddOptions(res);
    }


    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Is FullScreen", fsBool);

    }
}
