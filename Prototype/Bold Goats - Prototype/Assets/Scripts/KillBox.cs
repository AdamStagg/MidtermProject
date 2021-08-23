using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class KillBox : MonoBehaviour
{
    public GameObject text;
    void OnTriggerEnter(Collider collider) 
    {
        if (collider.tag == "Player") 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SoundManager.PlaySound(SoundManager.Sound.PlayerWaterDeath);
            
            text.SetActive(true);
            StartCoroutine(WaitSomeTime(2f));
            //SceneTransitionManager.Instance.LoadScene("LOSE_CONDITION");
        }
    }
    
    IEnumerator WaitSomeTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        SceneTransitionManager.Instance.LoadScene("LOSE_CONDITION");
    }
       
    
}
