using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public InteractionInputData interactionInputData;
    

    // Start is called before the first frame update
    void Start()
    {
        interactionInputData.ResetInput();
    }

    // Update is called once per frame
    void Update()
    {
        GetInteractionInputData();
    }

    void GetInteractionInputData()
    {
        interactionInputData.InteractedRelease = Input.GetKeyDown(KeyCode.E);
        //Debug.Log("E clicked" + interactionInputData.InteractedClick);
        interactionInputData.InteractedRelease = Input.GetKeyUp(KeyCode.E);
        //Debug.Log("E clicked" + interactionInputData.InteractedRelease);

    }
}
