using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinRoomCollider : MonoBehaviour
{
    public GameObject WinCam;
    // Start is called before the first frame update
    void Start()
    {
        WinCam.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            WinCam.SetActive(true);
        }
    }
}
