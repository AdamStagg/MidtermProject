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
        [SerializeField] float stateChangeDelay = 1f;
        [SerializeField] float maxSightAngle = 30;

        float timeTillCanBeSeen;
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

                if (dirToPlayer.magnitude <= 1)
                {
                    enemyState.InvokeChase();
                    GetComponent<EnemyPathFind>().SetLastPosition(transform);
                    return;
                }
                if (Mathf.Abs(Vector3.Angle(transform.forward, dirToPlayer)) <= maxSightAngle)
                {

                    //Raycast to the player, certain distance. 
                    if (Physics.Raycast(transform.position, dirToPlayer, out RaycastHit hit, visionLength))
                    {

                        //If we hit the player
                        if (hit.transform.gameObject == GameManager.Instance.Player)
                        {
                            ////Increase the suspicion meter based on the range
                            //fillRate = visionLength / Mathf.Pow(Mathf.Log10(dirToPlayer.magnitude), 2);
                            //Suspicion = Mathf.Clamp(Suspicion + fillRate * Time.deltaTime, 0, 100);

                            //close to the player, alert
                            //Saw the player in patrol, change to investigate.
                            if (enemyState.state == States.Patrol && timeTillCanBeSeen <= Time.time || enemyState.state == States.Return && timeTillCanBeSeen <= Time.time)
                            {
                                Debug.Log("hit the player");
                                enemyState.state = States.Investigate;
                                GetComponent<EnemyPathFind>().SetInvestigatePosition(GameManager.Instance.Player.transform);
                                timeTillCanBeSeen = Time.time + stateChangeDelay;
                                enemyState.InvokeInvestigate();
                            }
                            else if (enemyState.state == States.Investigate && Time.time >= timeTillCanBeSeen)
                            {
                                enemyState.InvokeChase();
                            }
                            //test


                            //if (Suspicion >= 95 && enemyState.state == States.Investigate)
                            //{
                            //    //Alert state
                            //    enemyState.InvokeChase();

                            //}
                            //else if (Suspicion >= 50 && enemyState.state == States.Patrol)
                            //{
                            //    //Suspicious state
                            //    enemyState.InvokeInvestigate();
                            //}
                        }
                    }
                }
            }
        }




        private void OnDrawGizmosSelected()
        {
            if (GameObject.Find("Player") != null)
            {
                Vector3 dirToPlayer = GameObject.Find("Player").transform.position - transform.position;
                dirToPlayer.Normalize();
                Gizmos.color = Color.red;
                Gizmos.DrawRay(transform.position, dirToPlayer * visionLength);
            }

        }


    }
}
