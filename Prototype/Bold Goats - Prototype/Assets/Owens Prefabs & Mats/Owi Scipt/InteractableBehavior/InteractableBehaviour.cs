using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBehaviour : InteractableBase
{
    [Space]
    public bool destroyType = false;
    public GameObject destroy;

    [Space]
    public bool hideType = false;
    //public Transform hidePoint;

    [Space]
    public bool transportType = false;
    public Transform transportPoint;

    public override void OnInteract()
    {
        base.OnInteract();

        if (destroyType == true)
        {

            Destroy(destroy);
        }
        else if (transportType == true)
        {
            GameManager.Instance.Player.transform.position = transportPoint.position;
        }
        else if (hideType == true)
        {
            GameManager.Instance.Player.transform.position = transform.position;
            GetComponent<Collider>().enabled = false;

            if (Vector3.Distance(GameManager.Instance.Player.transform.position, transform.position) > .03f)
            {
                GetComponent<Collider>().enabled = true;
            }
        }
    }

}
