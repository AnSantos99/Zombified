using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{

    public GameObject[] menus;

     public AudioSource clickSound;


    void Start()
    {
        foreach(GameObject subMenu in menus)
        {
            subMenu.SetActive(false);
        }
    }


// add toggle on anim
    public void ShowGameControls()
    {
         if(menus[1].activeSelf)
            menus[1].SetActive(false);
            
        if(menus[0].activeSelf)
            menus[0].SetActive(false);

        else
            menus[0].SetActive(true);

            clickSound.Play();
    }

     public void ShowControlsMenu()
    {
        if(menus[0].activeSelf)
            menus[0].SetActive(false);

        if(menus[1].activeSelf)
            menus[1].SetActive(false);

        else
            menus[1].SetActive(true);

            clickSound.Play();
    }
}
