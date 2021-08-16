using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

public class MovingSpotLight : MonoBehaviour
{

    [Header("Enemy creation")]
    public GameObject SpawnLocation;
    public GameObject enemyPrefab;
    
    [Header("Spotlight variables")]
    public GameObject[] waypoints;
    public float delayBeforeRespawn = 5f;

    float moveSpeed = 4f;
    float rotateSpeed = 1f;
    int waypointIndex = 0;

    float timeSinceLastSpawned;

    private void Update()
    {
        if (waypoints.Length == 0)
            return;

        Vector3 dirToWaypoint = waypoints[waypointIndex].transform.position - transform.position;
        dirToWaypoint.Normalize();
        transform.Translate(dirToWaypoint * moveSpeed * Time.deltaTime);
        transform.Rotate(dirToWaypoint * rotateSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position) < .1f)
        {
            UpdateWaypoint();
        }
    }

    void UpdateWaypoint()
    {
        if (waypoints.Length == 0) return;

        waypointIndex = (waypointIndex + 1) % waypoints.Length;
    }

    public void CallForBackUp(GameObject spawnLocation, int numEnemies, float timeBetweenEnemies = 0.5f)
    {
        if (spawnLocation != null)
        {
            if (timeSinceLastSpawned <= Time.time)
            {
                timeSinceLastSpawned = Time.time + delayBeforeRespawn;
                StartCoroutine(SpawnEnemiesWithDelay(spawnLocation, numEnemies, timeBetweenEnemies));
            }
        }
    }

    IEnumerator SpawnEnemiesWithDelay(GameObject spawnLocation, int numEnemies, float timeBetweenEnemies = 2)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            GameObject enemyCreated = Instantiate(enemyPrefab, spawnLocation.transform.position, Quaternion.identity);

            enemyCreated.GetComponent<EnemyPathFind>().SetInvestigatePosition(GameManager.Instance.Player.transform);
            enemyCreated.GetComponent<EnemyState>().InvokeInvestigate();

            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneTransitionManager.Instance.LoadScene("LOSE CONDITION");
            
        }
    }


}
