using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsSettings : MonoBehaviour
{
    Resolution[] resolutions;
    public TMPro.TMP_Dropdown resDropdown;

    public void ToggleFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
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
}
