using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class KillBox : MonoBehaviour
{
    void OnTriggerEnter(Collider collider) 
    {
        if (collider.tag == "Player") 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            SceneTransitionManager.Instance.LoadScene("LOSE_CONDITION");
        }
    }
    
       
    
}
