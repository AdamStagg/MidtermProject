using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathFind : MonoBehaviour
{
    [SerializeField]NavMeshAgent aiEnemy;
    Vector3 startPos;
    public float roamRadius = 15.00f;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        aiEnemy.SetDestination(player.transform.position);
        //if (aiEnemy.remainingDistance < .01f)
        //{
        //DirectionTest();

        //}
    }

    void DirectionTest()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 10;
        randomDirection += startPos;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, roamRadius, 1);
        NavMeshPath path = new NavMeshPath();
        aiEnemy.SetPath(path);

    }
}
