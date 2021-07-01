using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathFind : MonoBehaviour
{
    private NavMeshAgent aiEnemy;
    public Vector3[] gaurdPoints;
    private int destinationPoint;
    // Start is called before the first frame update
    void Start()
    {
        aiEnemy = GetComponent<NavMeshAgent>();

        GoToNextPoint();
    }



    // Update is called once per frame
    void Update()
    {
        //aiEnemy.SetDestination(player.transform.position);
        if (aiEnemy.remainingDistance < 1.0f && !aiEnemy.pathPending)
        {
            GoToNextPoint();
        }
    }

    void GoToNextPoint()
    {
        // If there are no points set, No Need to run Function
        if (gaurdPoints.Length == 0)
        {
            return;
        }

        // Set Gaurd point to the point currently selected
        aiEnemy.destination = gaurdPoints[destinationPoint];

        // Set Destination Point to next point
        destinationPoint = (destinationPoint + 1) % gaurdPoints.Length;
    }

    //void Patrol()
    //{
    //    Vector3 randomDirection = Random.insideUnitSphere * 10;
    //    randomDirection += startPos;
    //    NavMeshHit hit;
    //    NavMesh.SamplePosition(randomDirection, out hit, roamRadius, 1);
    //    NavMeshPath path = new NavMeshPath();
    //    aiEnemy.SetPath(path);

    //}
}
