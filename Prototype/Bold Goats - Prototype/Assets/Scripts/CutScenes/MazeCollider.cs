using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCollider : MonoBehaviour
{
    public GameObject MazeCam;
    // Start is called before the first frame update
    void Start()
    {
        MazeCam.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MazeCam.SetActive(true);
        }
    }
}
