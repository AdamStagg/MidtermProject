using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGateSwitch : MonoBehaviour
{
    public bool IsOn = true;
    public bool IsPermanentlyOn = false;
    public float SwitchTime = 3.0f;
    public GameObject Lasers;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Lasers.SetActive(IsOn);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPermanentlyOn == false) 
        {
            SwitchTime -= Time.deltaTime;
            if (SwitchTime < 0.1)
            {
                SwitchTime = 3.0f;
                anim.SetTrigger("Switch");
                //IsOn = !IsOn;
                //Lasers.SetActive(IsOn);
            }
        }
    }

  
}
