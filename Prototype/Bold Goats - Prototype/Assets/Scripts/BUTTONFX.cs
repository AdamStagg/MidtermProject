using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUTTONFX : MonoBehaviour
{
    public AudioSource FX;
    public AudioClip Hoverfx;
    public AudioClip Clickfx;

    public void HoverSound()
    {
        FX.PlayOneShot(Hoverfx);
    }
    public void ClickSound()
    {
        FX.PlayOneShot(Clickfx);
    }
}
