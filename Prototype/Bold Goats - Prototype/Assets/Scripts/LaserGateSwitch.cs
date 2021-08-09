using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGateSwitch : MonoBehaviour
{
    public bool IsOn = true;
    public float SwitchTime = 3.0f;
    public GameObject Lasers;
    // Start is called before the first frame update
    void Start()
    {
        Lasers.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        SwitchTime -= Time.deltaTime;
        if (SwitchTime < 0.1) 
        {
            SwitchTime = 3.0f;
            IsOn = !IsOn;
            Lasers.SetActive(IsOn);
        }
    }

  
}
