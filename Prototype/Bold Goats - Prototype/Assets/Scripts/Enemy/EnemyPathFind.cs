using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyPathFind : MonoBehaviour
    {
        private NavMeshAgent aiEnemy;
        public Vector3[] gaurdPoints;
        private int destinationPoint;

        EnemyState enemyState;

        // Start is called before the first frame update
        void Start()
        {
            aiEnemy = GetComponent<NavMeshAgent>();
            enemyState = GetComponent<EnemyState>();

            enemyState.state = States.Patrol;
            GoToNextPoint();
        }

        // Update is called once per frame
        void Update()
        {
            switch (enemyState.state)
            {
                case States.Alert:
                    break;
                case States.Attack:
                    break;
                case States.Chase:
                    aiEnemy.destination = GameManager.Instance.Player.transform.position;
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

        void GoToNextPoint()
        {
            // If there are no points set, No Need to continue Function
            if (gaurdPoints.Length == 0)
            {
                return;
            }

            // Set Gaurd point to the point currently selected
            aiEnemy.destination = gaurdPoints[destinationPoint];

            // Set Destination Point to next point
            destinationPoint = (destinationPoint + 1) % gaurdPoints.Length;
        }
    }
}
