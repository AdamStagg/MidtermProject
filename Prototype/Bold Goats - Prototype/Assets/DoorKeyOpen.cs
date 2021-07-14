using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyOpen : MonoBehaviour
{
    public GameObject Door;
    public Transform Hinge;
    public GameObject Key;

    public GameObject DoorCam;
    public Transform DoorCamEvent;
    public GameObject MainCam;

    public float speed;

    void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag == "Player")
        {
            Destroy(Key);

            DoorCam.SetActive(true);
            MainCam.SetActive(false);

            Door.transform.position = Vector3.MoveTowards(transform.position, Hinge.position, speed * Time.deltaTime);
            DoorCam.transform.position = Vector3.MoveTowards(transform.position, DoorCamEvent.position, speed * Time.deltaTime);
            StartCoroutine(WaitCorutine());
        }
    }

    IEnumerator WaitCorutine()
    {
        yield return new WaitForSeconds(3);
        DoorCam.SetActive(false);
        MainCam.SetActive(true);
    }
}
