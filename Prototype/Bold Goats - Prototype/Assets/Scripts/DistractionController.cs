using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
public class DistractionController : MonoBehaviour
{
    public Rigidbody DistractableRb;
    public GameObject explosion;
    public float speed = 8.0f;
    

    public List<EnemyState> enemies;

    void Start()
    {
       DistractableRb.velocity = (transform.forward + Vector3.up) * speed;
        enemies = new List<EnemyState>();
    }

    private void OnCollisionEnter(Collision hit)
    {
        foreach (EnemyState enemy in enemies)
        {
            enemy.InvokeInvestigate();
        }
        DistractableRb.isKinematic = true;
        explosion.SetActive(true);
        Destroy(gameObject, 2);
        //OnTriggerEnter(explosion.GetComponent<Collider>());
        for (int i = 0; i < enemies.Count; i++) 
        {
            enemies[i].transform.position = transform.position;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other = explosion.GetComponent<Collider>();

        if (other.transform.parent != null && other.tag == "Enemy")
        {
            enemies.Add(transform.parent.GetComponent<EnemyState>());

        }

    }

    /*private void OnTriggerExit(Collider other)
    {
        other = explosion.GetComponent<Collider>();

        if (other.transform.parent!= null && other.tag == "Enemy")
        {
            enemies.Remove(transform.parent.GetComponent<EnemyState>());

        }
    }
    */

    private void LateUpdate()
    {
       if (explosion == null && enemies.Count >=1) 
        {
            for (int i = 0; i < enemies.Count; i++) 
            {
                enemies.Remove(enemies[i]);
                i--;
            }
        }
    }


}
