using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlScript : MonoBehaviour
{
    [SerializeField] private InputActionReference input;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private TMP_Text bindDisplayName;
    [SerializeField] private GameObject startRebind;
    [SerializeField] private GameObject waitForInput;




    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    public void StartRebind()
    {
        startRebind.SetActive(false);
        waitForInput.SetActive(true);

        rebindingOperation = input.action.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => RebindComplete())
            .Start();
    }

    private void RebindComplete()
    {
        rebindingOperation.Dispose();

        startRebind.SetActive(true);
        waitForInput.SetActive(false);

        
    }
}
