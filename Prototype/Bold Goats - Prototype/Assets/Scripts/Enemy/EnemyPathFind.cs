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


        GameObject player;
        EnemyState enemyState;

        // Start is called before the first frame update
        void Start()
        {
            aiEnemy = GetComponent<NavMeshAgent>();
            enemyState = GetComponent<EnemyState>();
            player = GameObject.Find("Player");

            enemyState.state = States.Patrol;
            GoToNextPoint();
        }

        // Update is called once per frame
        void Update()
        {

            // Checking to see if player is in certain range from enemy so they stop chasing
            if (Vector3.Distance(player.transform.position, aiEnemy.transform.position) >= 5.0f)
            {
                enemyState.state = States.Patrol;
            }

            // Raycast knowledge to chase player
            NavMeshHit hit;
            if (!aiEnemy.Raycast(player.transform.position, out hit))
            {
                enemyState.state = States.Chase;
            }
            EnemyStateSwitch();
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

        // Switch for enemy behavior
        void EnemyStateSwitch()
        {
            switch (enemyState.state)
            {
                case States.Alert:
                    break;
                case States.Attack:
                    break;
                case States.Chase:
                    aiEnemy.destination = player.transform.position;
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
