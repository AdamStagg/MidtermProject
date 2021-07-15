using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Terminal : MonoBehaviour
{
    bool isLocked = true;
    [SerializeField] GameObject door;
    [SerializeField] Slider unlockBar;
 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (unlockBar.IsActive())
        {
            if (unlockBar.value < unlockBar.maxValue)
            {
                unlockBar.value += 0.05f * Time.deltaTime;
            }
            else if (unlockBar.value == unlockBar.maxValue)
            {
                isLocked = false;
            }
            if (isLocked == false)
                Destroy(door);
        }
    }
}
