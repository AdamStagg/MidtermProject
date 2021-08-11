using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public GameObject PlayerCamera;
    public GameObject HallwayCam;
    public GameObject SpotlightCam;
    public GameObject MazeCam;
    public GameObject LazerCam;
    public GameObject WinRoomCam;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        HallwayCam.SetActive(true);
        PlayerCamera.SetActive(false);

    }


    //void Start()
    //{
    //    StartCoroutine(StartingSequence());
    //}

    //IEnumerator StartingSequence()
    //{

    //    //HallwayCam.SetActive(true);
    //    //Controls.SetActive(false);
    //    ////PlayerCamera.SetActive(false);
    //    //yield return new WaitForSeconds(7.5f);
        
    //    //SpotlightCam.SetActive(true);
    //    //HallwayCam.SetActive(false);
    //    //yield return new WaitForSeconds(4.5f);
        
    //    //PalaceCam.SetActive(true);
    //    //SpotlightCam.SetActive(false);
    //    //yield return new WaitForSeconds(5);

    //    ////PlayerCamera.SetActive(true);
    //    //PalaceCam.SetActive(false);




    //}

}
