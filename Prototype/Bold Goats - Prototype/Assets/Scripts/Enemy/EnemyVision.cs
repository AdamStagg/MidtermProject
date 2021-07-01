using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float visionLength;
    [SerializeField] float fillRate = 0.25f;

    [Range(0, 100)] float suspicion;

    public float Suspicion
    {
        get { return suspicion; }
        private set { suspicion = value; }
    }

    public delegate void StateChange();
    public event StateChange Alert;
    public event StateChange Investigate;



    private void Update()
    {

        //Raycast to the player, certain distance. 
        if (Physics.Raycast(transform.position, player.transform.position - transform.position, out RaycastHit hit, visionLength))
        {
            //If we hit the player
            if (hit.transform.gameObject == player)
            {
                //Increase the suspicion meter based on the range
                fillRate = visionLength / (player.transform.position - transform.position).magnitude / 4;
                Suspicion += fillRate * Time.deltaTime;

                if (Suspicion >= 95)
                {
                    //Alert state
                    if (Alert != null)
                    {
                        Alert.Invoke();
                    }
                }
                else if (Suspicion >= 50)
                {
                    //Suspicious state
                    if (Investigate != null)
                    {
                        Investigate.Invoke();
                    }
                }
            }
        }
    }

}
