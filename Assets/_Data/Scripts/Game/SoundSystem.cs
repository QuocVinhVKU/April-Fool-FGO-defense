using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public GameObject panelSoundOn;
    public GameObject panelSoundOff;

    public void PressSoundOn()
    {
        AudioListener.volume = 0f;
        panelSoundOn.SetActive(false);
        panelSoundOff.SetActive(true);
    }
    public void PressSoundOff()
    {
        AudioListener.volume = 1f;
        panelSoundOn.SetActive(true);
        panelSoundOff.SetActive(false);
    }
}

