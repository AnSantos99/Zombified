using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class ToggleSound : MonoBehaviour
{

    public AudioMixer mixer;

    public TextMeshProUGUI toggleText;

    public GameObject Sounds;

    void start()
    {

    }

    public void SoundToggle()
    {
        if(toggleText.text == "ON")
        {
            toggleText.text = "OFF";
            AudioListener.pause = true;
        }

        else
        {
            toggleText.text = "ON";
            AudioListener.pause = false;
        }
     
    }
}
