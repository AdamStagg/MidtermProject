using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayCollider : MonoBehaviour
{
    public GameObject HallwayCam;
    // Start is called before the first frame update
    void Start()
    {
        HallwayCam.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            HallwayCam.SetActive(true);
        }
    }
}
