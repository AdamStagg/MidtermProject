using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightCollision : MonoBehaviour
{

    public GameObject SpotlightCam;
    public GameObject PlayerCam;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        SpotlightCam.SetActive(true);
        PlayerCam.SetActive(false);
        StartCoroutine(FinishCutScene());
    }

    IEnumerator FinishCutScene()
    {
        yield return new WaitForSeconds(7);
        PlayerCam.SetActive(true);
        SpotlightCam.SetActive(false);
    }
}
