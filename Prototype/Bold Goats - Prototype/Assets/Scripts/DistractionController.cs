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
            EnemyPathFind enemypf = enemy.GetComponent<EnemyPathFind>();
            enemypf.SetInvestigatePosition(transform);
            enemypf.lookingAround = false;
            enemypf.StopAllCoroutines();
            enemypf.ResumeNavigation();
            enemy.InvokeInvestigate();
        }
        DistractableRb.isKinematic = true;
        explosion.SetActive(true);
        SoundManager.PlaySound(SoundManager.Sound.DistractionExplosion);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != null && other.transform.parent.tag == "Enemy")
        {
            enemies.Add(other.transform.parent.GetComponent<EnemyState>());
        }

    }

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
