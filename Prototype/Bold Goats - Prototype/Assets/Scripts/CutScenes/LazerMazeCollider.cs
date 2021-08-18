using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerMazeCollider : MonoBehaviour
{
    public GameObject LazerMazeCam;
    public GameObject PlayerCam;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        LazerMazeCam.SetActive(true);
        PlayerCam.SetActive(false);
        StartCoroutine(FinishCutScene());   
    }

    IEnumerator FinishCutScene()
    {
        yield return new WaitForSeconds(5);
        PlayerCam.SetActive(true);
        LazerMazeCam.SetActive(false);
    }
}
