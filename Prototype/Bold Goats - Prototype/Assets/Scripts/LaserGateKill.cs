using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGateKill : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            //Destroy(GameManager.Instance.Player);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            SceneTransitionManager.Instance.LoadScene("LOSE CONDITION");
        }
    }
}
