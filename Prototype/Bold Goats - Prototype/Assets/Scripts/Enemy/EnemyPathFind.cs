using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    [RequireComponent(typeof(EnemyVision))]
    public class EnemyPathFind : MonoBehaviour
    {
        private NavMeshAgent aiEnemy;
        public Transform[] guardPoints;
        private int destinationPoint = 0;

        Transform lastPosition;

        EnemyVision enemyVision;

        GameObject player;
        EnemyState enemyState;

        [SerializeField] float maxDistanceForChase = 10f;
        [SerializeField] float distanceToAttack = 2f;

        [SerializeField] Material attackMaterial;

        // Start is called before the first frame update
        void Awake()
        {
            aiEnemy = GetComponent<NavMeshAgent>();
            enemyState = GetComponent<EnemyState>();
            enemyVision = GetComponent<EnemyVision>();

            enemyState.Chase += HandleInvokeChase;

            lastPosition = new GameObject().transform;

            enemyState.state = States.Patrol;
            GoToNextPoint();
        }

        private void OnDisable()
        {
            enemyState.Chase -= HandleInvokeChase;
        }

        // Update is called once per frame
        void Update()
        {

           

            PerformNavigation();
        }

        void GoToNextPoint()
        {
            // If there are no points set, No Need to continue Function
            
            //if (gaurdPoints.Length == 0)
            //{
            //    return;
            //}

            // Set Gaurd point to the point currently selected
            aiEnemy.destination = guardPoints[destinationPoint].position;

            // Set Destination Point to next point
            destinationPoint = (destinationPoint + 1) % guardPoints.Length;
        }

        public void HandleInvokeChase()
        {
            lastPosition.position = transform.position;
        }

        // Switch for enemy behavior
        void PerformNavigation()
        {
            switch (enemyState.state)
            {
                case States.Alert:
                    break;
                case States.Attack:

                    

                    break;
                case States.Chase:

                    
                    aiEnemy.destination = GameManager.Instance.Player.transform.position;

                    float distance = Vector3.Distance(transform.position, GameManager.Instance.Player.transform.position);

                    if (distance >= maxDistanceForChase)
                    {
                        enemyState.InvokeReturn();
                    } else if (distance <= distanceToAttack)
                    {
                        aiEnemy.isStopped = true;
                        aiEnemy.ResetPath();
                        enemyState.InvokeAttack();
                    }


                    break;
                case States.Death:



                    break;
                case States.Investigate:
                    break;
                case States.Patrol:
                    
                    if (aiEnemy.remainingDistance < 1.0f && !aiEnemy.pathPending)
                    {
                        GoToNextPoint();
                    }

                    break;
                case States.Return:

                    aiEnemy.destination = lastPosition.position;

                    if (aiEnemy.remainingDistance <= 1.0f && !aiEnemy.pathPending)
                    {
                        destinationPoint--;
                        if (destinationPoint < 0)
                        {
                            destinationPoint = guardPoints.Length - 1;
                        }

                        enemyState.InvokePatrol();
                    }
                    break;
                default:
                    break;
            }

        }
    }
}
