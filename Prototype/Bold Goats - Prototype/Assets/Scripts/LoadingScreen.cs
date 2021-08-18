using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class LoadingScreen : MonoBehaviour
{

    public Slider slider;
   
    void Start()
    {
        slider.value = 0;
    }

    void Update()
    {
        slider.value += Time.deltaTime * 4;
        if (slider.value >= 100) 
        {
            SceneTransitionManager.Instance.LoadScene("Palace");
        }
    }
}
