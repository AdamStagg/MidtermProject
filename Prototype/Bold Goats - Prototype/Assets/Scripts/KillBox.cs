using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            SceneTransitionManager.Instance.LoadScene("LOSE_CONDITION");
        }
    }
}
