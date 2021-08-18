using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightCollision : MonoBehaviour
{
    public GameObject SpotlightCam;
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
        SpotlightCam.SetActive(true);
        PlayerCam.SetActive(false);
        yield return new WaitForSeconds(8);
        PlayerCam.SetActive(true);
        SpotlightCam.SetActive(false);

    }

    void SkipScene()
    {
        StopAllCoroutines();
        PlayerCam.SetActive(true);
        SpotlightCam.SetActive(false);
        Debug.Log("Stop Scene");
    }
}
