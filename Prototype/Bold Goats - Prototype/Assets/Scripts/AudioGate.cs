using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGate : MonoBehaviour
{
    // Start is called before the first frame update
    bool entered = false;
    public AudioSource audio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            entered = !entered;

            if (entered == true)
            {
                audio.Play();
            }
            else 
            {
                audio.Stop();
            }
        }
    }
}
