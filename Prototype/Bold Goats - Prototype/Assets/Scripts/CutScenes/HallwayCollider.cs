using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayCollider : MonoBehaviour
{
    public GameObject HallwayCam;
    public GameObject PlayerCam;
    public GameObject skipText;

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
        skipText.SetActive(true);
        HallwayCam.SetActive(true);
        PlayerCam.SetActive(false);
        yield return new WaitForSeconds(8);
        PlayerCam.SetActive(true);
        HallwayCam.SetActive(false);
        skipText.SetActive(false);

    }

    void SkipScene()
    {
        StopAllCoroutines();
        PlayerCam.SetActive(true);
        HallwayCam.SetActive(false);
        skipText.SetActive(false);
    }
}
