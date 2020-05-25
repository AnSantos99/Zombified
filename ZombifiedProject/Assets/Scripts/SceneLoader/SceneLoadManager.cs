using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadManager : MonoBehaviour
{
    public GameObject[] scenes;


    void Start()
    {
        foreach(GameObject scene in scenes)
        {
            scene.SetActive(false);
        }
    }


// add toggle on anim
    public void ShowScenes()
    {
         if(!scenes[0].activeSelf)
           {
               foreach(GameObject scene in scenes)
        {
            scene.SetActive(true);
        }
           }

        else    
           {
                foreach(GameObject scene in scenes)
        {
            scene.SetActive(false);
        }
           }
    }
}
