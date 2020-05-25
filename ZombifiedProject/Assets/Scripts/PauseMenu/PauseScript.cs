using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;
 
 public class PauseScript : MonoBehaviour {
 
     public Transform canvas;

     public Player player;

    public Text text;



     public void SaveGame()
     {
            SaveLoad.SavePlayer(player);
     }

     public void LoadGame()
     {
         PlayerData data = SaveLoad.LoadPlayer();

         player.Name = data.Name;
         player.Age = data.Age;

         Vector3 position;

         position.x = data.position[0];
         position.y = data.position[1];
         position.z = data.position[2];

         player.transform.position = position;
     }
         
     void Update () {
         if(Input.GetKeyDown("p"))
            {
             if (canvas.gameObject.activeInHierarchy == false) {        
                 canvas.gameObject.SetActive (true);
                 Time.timeScale = 0;
             } else 
             {
                 canvas.gameObject.SetActive (false);
                 Time.timeScale = 1;
             }
         } 

         text.text = player.Name;
     }
 }

