using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinRoomCollider : MonoBehaviour
{
    public GameObject WinRoomCam;
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
        WinRoomCam.SetActive(true);
        PlayerCam.SetActive(false);
        yield return new WaitForSeconds(8);
        PlayerCam.SetActive(true);
        WinRoomCam.SetActive(false);

    }

    void SkipScene()
    {
        StopAllCoroutines();
        PlayerCam.SetActive(true);
        WinRoomCam.SetActive(false);
        Debug.Log("Stop Scene");
    }
}
