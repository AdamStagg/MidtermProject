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
        public Transform[] gaurdPoints;
        private int destinationPoint = 0;

        EnemyVision enemyVision;

        GameObject player;
        EnemyState enemyState;

        [SerializeField] float maxDistanceForChase = 10f;
        [SerializeField] float distanceToAttack = 1f;

        // Start is called before the first frame update
        void Awake()
        {
            aiEnemy = GetComponent<NavMeshAgent>();
            enemyState = GetComponent<EnemyState>();
            enemyVision = GetComponent<EnemyVision>();

            enemyState.state = States.Patrol;
            GoToNextPoint();
        }

        // Update is called once per frame
        void Update()
        {

            if (GameManager.Instance.Player != null)
            {
                // Checking to see if player is in certain range from enemy so they stop chasing
                if (Vector3.Distance(GameManager.Instance.Player.transform.position, aiEnemy.transform.position) >= 5.0f)
                {
                    enemyState.state = States.Patrol;
                }
            }

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
            aiEnemy.destination = gaurdPoints[destinationPoint].position;

            // Set Destination Point to next point
            destinationPoint = (destinationPoint + 1) % gaurdPoints.Length;
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

                    aiEnemy.destination = player.transform.position;

                    float distance = Vector3.Distance(transform.position, GameManager.Instance.Player.transform.position);

                    if (distance >= maxDistanceForChase)
                    {
                        enemyState.InvokeReturn();
                    } else if (distance <= distanceToAttack)
                    {
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
                    break;
                default:
                    break;
            }

        }
    }
}
