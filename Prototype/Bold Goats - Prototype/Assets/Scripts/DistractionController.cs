using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
public class DistractionController : MonoBehaviour
{
    public Rigidbody DistractableRb;
    public GameObject explosion;
    public float speed = 8.0f;
    public int destroyTime = 2;

    void Start()
    {
       DistractableRb.velocity = (transform.forward + Vector3.up) * speed; 
    }

    private void OnCollisionEnter(Collision hit)
    {
        DistractableRb.isKinematic = true;
        explosion.SetActive(true);
        Destroy(gameObject, destroyTime);
        OnTriggerEnter(explosion.GetComponent<Collider>());
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") 
        {
            EnemyState enemy = new EnemyState();
            enemy.InvokeInvestigate();
        }
    }


}
