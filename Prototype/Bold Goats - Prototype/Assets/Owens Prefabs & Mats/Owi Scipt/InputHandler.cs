using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public InteractionInputData interactionInputData;
    private Input inputActions;

    private void Awake()
    {
        inputActions = new Input();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
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
        interactionInputData.InteractedRelease = UnityEngine.Input.GetButton("Interact");
        //Debug.Log("E clicked" + interactionInputData.InteractedClick);
        interactionInputData.InteractedRelease = UnityEngine.Input.GetButton("Interact");
        //Debug.Log("E clicked" + interactionInputData.InteractedRelease);

    }
}
