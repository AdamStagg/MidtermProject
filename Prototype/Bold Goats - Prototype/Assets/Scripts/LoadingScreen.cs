using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadingScreen : MonoBehaviour
{

    public Slider slider;
   
    void Start()
    {
        slider.value = 0;
    }

    void Update()
    {
        slider.value += Time.deltaTime;
        if (slider.value >= 3) 
        {
            SceneManager.LoadScene("Palace");
        }
    }
}
