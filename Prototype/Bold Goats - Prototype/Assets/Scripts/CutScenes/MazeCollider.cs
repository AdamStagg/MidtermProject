using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCollider : MonoBehaviour
{
    public GameObject MazeCam;
    public GameObject PlayerCam;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SkipScene();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;

        StartCoroutine(FinishCutScene());
    }

    IEnumerator FinishCutScene()
    {
        MazeCam.SetActive(true);
        PlayerCam.SetActive(false);
        yield return new WaitForSeconds(8);
        PlayerCam.SetActive(true);
        MazeCam.SetActive(false);

    }

    void SkipScene()
    {
        StopAllCoroutines();
        PlayerCam.SetActive(true);
        MazeCam.SetActive(false);
        Debug.Log("Stop Scene");
    }
}
