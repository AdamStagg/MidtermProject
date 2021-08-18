using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyState))]
    public class EnemyVision : MonoBehaviour
    {
        EnemyState enemyState;

        public float visionLength;
        [SerializeField] float stateChangeDelay = 1f;
        public float maxSightAngle = 30;

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
                Debug.Log("Checking for player");
                Vector3 dirToPlayer = GameManager.Instance.Player.transform.position - transform.position;

                dirToPlayer = new Vector3(dirToPlayer.x, dirToPlayer.y + 1, dirToPlayer.z);

                if (dirToPlayer.magnitude <= 2)
                {
                    Debug.Log("Chasing");
                    enemyState.InvokeChase();
                    GetComponent<EnemyPathFind>().SetLastPosition(transform);
                    return;
                }
                if (Mathf.Abs(Vector3.Angle(transform.forward, dirToPlayer)) <= maxSightAngle/2)
                {
                    //Raycast to the player, certain distance. 
                    if (Physics.Raycast(transform.position, dirToPlayer, out RaycastHit hit, visionLength))
                    {
                        
                        //If we hit the player
                        Debug.Log(hit.transform.gameObject);
                        Debug.Log(GameManager.Instance.Player);
                        if (hit.transform.gameObject == GameManager.Instance.Player)
                        {

                            if (enemyState.state == States.Patrol && timeTillCanBeSeen <= Time.time || enemyState.state == States.Return && timeTillCanBeSeen <= Time.time)
                            {
                                Debug.Log("hit the player");
                                enemyState.state = States.Investigate;
                                GetComponent<EnemyPathFind>().SetInvestigatePosition(GameManager.Instance.Player.transform);
                                GetComponent<EnemyPathFind>().StopAllCoroutines();
                                GetComponent<EnemyPathFind>().ResumeNavigation();
                                timeTillCanBeSeen = Time.time + stateChangeDelay;
                                enemyState.InvokeInvestigate();
                            }
                            else if (enemyState.state == States.Investigate && Time.time >= timeTillCanBeSeen)
                            {
                                enemyState.InvokeChase();
                            }
                           
                        }
                    }
                }
            }
        }




        private void OnDrawGizmosSelected()
        {
            GameObject player = GameObject.Find("Player");

            if (player != null)
            {
                Vector3 dirToPlayer = player.transform.position - transform.position;
                dirToPlayer.Normalize();
                Gizmos.color = Color.red;
                Gizmos.DrawRay(transform.position, dirToPlayer * visionLength);
            }

        }


    }
}
