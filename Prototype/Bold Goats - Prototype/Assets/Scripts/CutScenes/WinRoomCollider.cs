using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinRoomCollider : MonoBehaviour
{
    public GameObject WinCam;
    public GameObject PlayerCam;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {

        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        WinCam.SetActive(true);
        PlayerCam.SetActive(false);
        StartCoroutine(FinishCutScene());
    }

    IEnumerator FinishCutScene()
    {
        yield return new WaitForSeconds(8);
        PlayerCam.SetActive(true);
        WinCam.SetActive(false);
    }
}
