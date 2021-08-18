using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayCollider : MonoBehaviour
{
    public GameObject HallwayCam;
    public GameObject PlayerCam;

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        HallwayCam.SetActive(true);
        PlayerCam.SetActive(false);
               
        StartCoroutine(FinishCutScene());       
    }

    IEnumerator FinishCutScene()
    {
        yield return new WaitForSeconds(8);
        PlayerCam.SetActive(true);
        HallwayCam.SetActive(false);

        if (Input.GetKey(KeyCode.G))
        {            
            PlayerCam.SetActive(true);
            HallwayCam.SetActive(false);
        }
    }

    //IEnumerator SkipScene()
    //{
    //    yield return new WaitForSeconds(0);
    //    PlayerCam.SetActive(true);
    //    HallwayCam.SetActive(false);
    //}
}
