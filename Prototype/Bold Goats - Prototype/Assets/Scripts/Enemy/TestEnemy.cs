using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

public class TestEnemy : MonoBehaviour
{

    public GameObject Spawn;
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(LookAround(5, 75));
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.H))
        //{
            //CallForBackUp(Spawn, 3);
        //}
    }


    //public void CallForBackUp(GameObject spawnLocation, int numEnemies, float timeBetweenEnemies = 0.5f)
    //{
    //    StartCoroutine(SpawnEnemiesWithDelay(spawnLocation, numEnemies, timeBetweenEnemies));    
        
    //}

    //IEnumerator SpawnEnemiesWithDelay(GameObject spawnLocation, int numEnemies, float timeBetweenEnemies = 2)
    //{
    //    for (int i = 0; i < numEnemies; i++)
    //    {
    //        GameObject enemyCreated = Instantiate(enemyPrefab, spawnLocation.transform.position, Quaternion.identity);

    //        enemyCreated.GetComponent<EnemyPathFind>().SetInvestigatePosition(GameManager.Instance.Player.transform);
    //        enemyCreated.GetComponent<EnemyState>().InvokeInvestigate();

    //        yield return new WaitForSeconds(timeBetweenEnemies);
    //    }
    //}





    //IEnumerator LookAround(int timeToLook, float _angleToRotate)
    //{
    //    //initialized variables
    //    Vector3 currentDir = transform.forward, originalDir = transform.forward;
    //    float angleToRotate = _angleToRotate;
    //    float degreesPerSecond = angleToRotate / ((float)timeToLook/4f);
        
    //    //defines the vector that is rotated to the target
    //    Vector3 targetLeft = Quaternion.Euler(0, -angleToRotate, 0) * currentDir;
    //    Vector3 targetRight = Quaternion.Euler(0, angleToRotate, 0) * currentDir;

    //    //Loops until the angle is smaller than 5
    //    while (Mathf.Abs(Vector3.Angle(currentDir, targetLeft)) > 5)
    //    {
    //        //degrees per second based on the time to look

    //        //rotates and updates the dir
    //        transform.Rotate(new Vector3(0, -degreesPerSecond * Time.deltaTime, 0));
    //        currentDir = transform.forward;
    //        yield return null;
    //    }

    //    //Do the same thing all the way right
    //    while (Mathf.Abs(Vector3.Angle(currentDir, targetRight)) > 5)
    //    {
    //        transform.Rotate(new Vector3(0, degreesPerSecond * Time.deltaTime, 0));
    //        currentDir = transform.forward;
    //        yield return null;
    //    }

    //    //Return to center
    //    while (Mathf.Abs(Vector3.Angle(currentDir, originalDir)) > 5)
    //    {
    //        transform.Rotate(new Vector3(0, -degreesPerSecond * Time.deltaTime, 0));
    //        currentDir = transform.forward;
    //        yield return null;
    //    }
    //}
}
