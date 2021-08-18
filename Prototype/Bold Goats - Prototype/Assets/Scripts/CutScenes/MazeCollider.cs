using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCollider : MonoBehaviour
{
    public GameObject MazeCam;
    public GameObject PlayerCam;
    // Start is called before the first frame update
 
    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        MazeCam.SetActive(true);
        PlayerCam.SetActive(false);
        StartCoroutine(FinishCutScene());
    }

    IEnumerator FinishCutScene()
    {
        yield return new WaitForSeconds(7);
        PlayerCam.SetActive(true);
        MazeCam.SetActive(false);
    }
}
