using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] public Image amountOfDistractables;
    public Image[] xAmountOfDistractables = new Image[4];

    // Update is called once per frame
    void Update()
    {
        amountOfDistractables = xAmountOfDistractables[PlayerController.AmountOfDistractables];
    }
}
