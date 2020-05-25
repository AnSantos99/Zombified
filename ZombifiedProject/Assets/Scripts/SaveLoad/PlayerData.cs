using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string Name;
    public int Age;
    public float[] position;

    public PlayerData(Player player)
    {
        Name = player.Name;
        Age = player.Age;

        position = new float[3];
        
            position[0] = player.transform.position.x;
            position[0] = player.transform.position.y;
            position[0] = player.transform.position.z;
    

    }
}
