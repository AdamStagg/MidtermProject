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

    [Space]
    public GameObject textToDisplay;
    public float timeToDisplayText = 5f;
    public override void OnInteract()
    {
        base.OnInteract();

        if (destroyType == true)
        {
            if (textToDisplay != null)
            {
            textToDisplay.SetActive(true);
            StartCoroutine(WaitSomeTime(timeToDisplayText));
            }
            if (destroy != null)
            {
                Destroy(destroy);
                GameManager.Instance.keyCards++;
            }

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

    IEnumerator WaitSomeTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        textToDisplay.SetActive(false);
        Destroy(this);
    }

}
