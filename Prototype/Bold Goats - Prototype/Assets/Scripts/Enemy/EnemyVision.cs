using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyState))]
    public class EnemyVision : MonoBehaviour
    {
        EnemyState enemyState;

        [SerializeField] float visionLength;
        [SerializeField] float fillRate = 0.25f;
        [SerializeField] float maxSightAngle = 30;

        [Range(0, 100)] public float Suspicion;
        public bool checkForPlayer = false;

        private void Awake()
        {
            enemyState = GetComponent<EnemyState>();
        }

        private void Update()
        {
            //TODO Add angle checks
            
            

            if (checkForPlayer && GameManager.Instance.Player != null)
            {
                Vector3 dirToPlayer = GameManager.Instance.Player.transform.position - transform.position;
                
                if (Mathf.Abs(Vector3.Angle(transform.forward, dirToPlayer)) <= maxSightAngle)

                //Raycast to the player, certain distance. 
                if (Physics.Raycast(transform.position, dirToPlayer, out RaycastHit hit, visionLength))
                {

                    //If we hit the player
                    if (hit.transform.gameObject == GameManager.Instance.Player)
                    {
                        //Increase the suspicion meter based on the range
                        fillRate = visionLength / Mathf.Pow(Mathf.Log10(dirToPlayer.magnitude), 2);
                        Suspicion = Mathf.Clamp(Suspicion + fillRate * Time.deltaTime, 0, 100);

                        if (Suspicion >= 95 && enemyState.state == States.Investigate)
                        {
                            //Alert state
                            enemyState.InvokeChase();

                        }
                        else if (Suspicion >= 50 && enemyState.state == States.Patrol)
                        {
                            //Suspicious state
                            enemyState.InvokeInvestigate();
                        }
                    }
                } else
                {
                    Suspicion = Mathf.Clamp(Suspicion - Time.deltaTime, 0, 100);
                }
            }
        }


        private void OnTriggerEnter(Collider other)
        {

            if (other.tag == "Player")
            {
                checkForPlayer = true;
            } else if (other.tag == "Enemy")
            {
                other.GetComponent<EnemyState>().Alert += HandleAlert;
            }


        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                checkForPlayer = false;
            } else if (other.tag == "Enemy")
            {
                other.GetComponent<EnemyState>().Alert -= HandleAlert;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Vector3 dirToPlayer = GameObject.Find("Player").transform.position - transform.position;
            dirToPlayer.Normalize();
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, dirToPlayer * visionLength);

        }

        void HandleAlert()
        {
            throw new System.NotImplementedException();
        }

    }
}
