using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiController : MonoBehaviour
{
    public Transform Target;
    public Transform KunaiPosition;
    public Rigidbody KunaiRb;
    public GameObject Kunai;

    public float RotationSpeed;
    public float KunaiVelocity = 10.0f;

    void Start() 
    {
        KunaiPosition = GetComponent<Transform>();

    }
   
    void FixedUpdate()
    {
        if (KunaiRb == null)
        {
          return;
        }

        KunaiRb.velocity = KunaiPosition.forward * KunaiVelocity;
        var KunaiRotation = Quaternion.LookRotation(Target.position - KunaiPosition.position);
        KunaiRb.MoveRotation(Quaternion.RotateTowards(KunaiPosition.rotation, KunaiRotation, RotationSpeed));
    }
   

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Enemy")
        {
            Destroy(Kunai);
            Debug.Log("It's a hit!");
        }
        else if(other.tag == "Wall")
        {
            Destroy(Kunai);
            Debug.Log("Hit a wall");
        }
    }
}
