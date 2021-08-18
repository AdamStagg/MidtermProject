using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
 
    //Update is called once per frame
    void Update()
    {
        //Input 
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        //Movement
        Vector3 Movement = new Vector3(Horizontal, 0f, Vertical);

        //Animation
        float VelocityZ = Vector3.Dot(Movement.normalized, transform.forward);
        float VelocityX = Vector3.Dot(Movement.normalized, transform.right);

        animator.SetFloat("VelocityZ", Horizontal, 0.1f, Time.deltaTime);
        animator.SetFloat("VelocityX", Vertical, 0.1f, Time.deltaTime);

    }
}
