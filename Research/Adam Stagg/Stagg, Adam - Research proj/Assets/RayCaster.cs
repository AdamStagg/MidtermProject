using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{

    [SerializeField] float rayCastLength;
    [SerializeField] float numRayCast;

    [SerializeField] Material hitMaterial;
    [SerializeField] Material initMaterial;

    [SerializeField] GameObject[] collidableObj;

    [SerializeField] LayerMask layerToCheck;

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;

        for (int i = 0; i < collidableObj.Length; i++)
        {
            collidableObj[i].GetComponent<MeshRenderer>().material = initMaterial;
        }

        for (int i = 0; i < 2; i++)
        {
            dir.x = i == 0 ? 1 : -1;
            dir.y = 0;
            dir.z = 0;

            if (Physics.Raycast(transform.position, dir, out RaycastHit hit, rayCastLength, layerToCheck, QueryTriggerInteraction.Collide))
            {
                //if ray hit, change the color and debug a message
                hit.transform.GetComponent<MeshRenderer>().material = hitMaterial;
                //Debug.Log("YOU HAVE HIT " + hit.transform.gameObject.name);
            }

        }
    }

    private void OnDrawGizmos()
    {


        for (int i = 0; i < 2; i++)
        {
        Vector3 dir = Vector3.zero;
            dir.x = i == 0 ? 1 : -1;
            dir.y = 0;
            dir.z = 0;
            Gizmos.DrawRay(transform.position, dir * rayCastLength);
        }

    }
}

