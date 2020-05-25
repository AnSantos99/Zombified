using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour
{
   public AudioMixer mixer;

   public void SetLevel(float sliderValue)
   {
       mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
   }

   public void SetMusicLevel(float sliderValue)
   {
       mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
   }

   public void SetSFXLevel(float sliderValue)
   {
       mixer.SetFloat("SfxVol", Mathf.Log10(sliderValue) * 20);
   }
}
