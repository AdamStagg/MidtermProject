using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightCollision : MonoBehaviour
{

    public GameObject SpotlightCam;
    // Start is called before the first frame update
    void Start()
    {
        SpotlightCam.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SpotlightCam.SetActive(true);          
        }
    }
}
