using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiController : MonoBehaviour
{
    public Transform Target;
    public Transform KunaiPosition;
    public Rigidbody Kunai;

    public float RotationSpeed;
    public float KunaiVelocity = 10.0f;

    void Start() 
    {
        KunaiPosition = GetComponent<Transform>();

    }
   
    void FixedUpdate()
    {
        if (Kunai == null)
        {
          return;
        }

        Kunai.velocity = KunaiPosition.forward * KunaiVelocity;
        var KunaiRotation = Quaternion.LookRotation(Target.position - KunaiPosition.position);
        Kunai.MoveRotation(Quaternion.RotateTowards(KunaiPosition.rotation, KunaiRotation, RotationSpeed));
    }
   

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Target") 
        {
            Destroy(Kunai);
            Debug.Log("It's a hit!");
        }
    }
}
