using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalAccess : MonoBehaviour
{
    [SerializeField] GameObject unlockBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.name == "KeyPad" && Input.GetKeyDown(KeyCode.J))
        {
            unlockBar.SetActive(true);
        }
    }
}
