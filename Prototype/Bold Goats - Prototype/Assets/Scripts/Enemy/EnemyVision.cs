using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyState))]
    public class EnemyVision : MonoBehaviour
    {
        EnemyState enemyState;


        [SerializeField] float visionLength;
        [SerializeField] float fillRate = 0.25f;

        [Range(0, 100)] float suspicion;
        bool checkForPlayer = false;

        public float Suspicion
        {
            get { return suspicion; }
            private set { suspicion = value; }
        }

        private void Awake()
        {
            enemyState = GetComponent<EnemyState>();
        }

       



        private void Update()
        {
            //TODO Add angle checks
            
            

            if (checkForPlayer && GameManager.Instance.Player != null)
            {
                Vector3 dirToPlayer = GameManager.Instance.Player.transform.position - transform.position;



                //Raycast to the player, certain distance. 
                if (Physics.Raycast(transform.position, dirToPlayer, out RaycastHit hit, visionLength))
                {
                    //If we hit the player
                    if (hit.transform.gameObject == GameManager.Instance.Player)
                    {
                        //Increase the suspicion meter based on the range
                        fillRate = visionLength / dirToPlayer.magnitude / 4;
                        Suspicion += fillRate * Time.deltaTime;

                        if (Suspicion >= 95)
                        {
                            //Alert state
                            Alert();
                        }
                        else if (Suspicion >= 50)
                        {
                            //Suspicious state
                            Investigate();
                        }
                    }
                }
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                checkForPlayer = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                checkForPlayer = false;
            }
        }

        void Alert()
        {
            enemyState.InvokeAlert();
        }

        void Investigate()
        {
            enemyState.InvokeInvestigate();
        }

    }
}
