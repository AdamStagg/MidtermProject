using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyOpen : MonoBehaviour
{
    public GameObject Door;
    public Transform Hinge;
    public GameObject Key;
    public GameObject UI;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");
        Destroy(this.gameObject);
        Door.transform.position = Hinge.position;
        UI.SetActive(true);
    }

   
}
