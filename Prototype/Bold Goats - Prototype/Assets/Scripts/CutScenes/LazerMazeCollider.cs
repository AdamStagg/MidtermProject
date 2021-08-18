using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerMazeCollider : MonoBehaviour
{
    public GameObject LazerMazeCam;
    void Start()
    {
        LazerMazeCam.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            LazerMazeCam.SetActive(true);
        }
    }
}
