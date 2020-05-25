using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSelection : MonoBehaviour
{

    public Animator zombieA;

    public Animator zombieB;

    public void SelectZombie(string Name)
    {
        if(Name == "A")
            zombieA.SetBool("Selected", true);
        else
            zombieB.SetBool("Selected", true);
    }

    public void UnselectZombie(string Name)
    {
        if(Name == "A")
            zombieA.SetBool("Selected", false);
        else
            zombieB.SetBool("Selected", false);
    }

    public void ClickZombie(string Name)
    {
        if(Name == "A")
        {
            zombieB.SetBool("NotSelected", true);
            zombieA.SetBool("Accepted", true);
        }
            
        else
        {
             zombieA.SetBool("NotSelected", true);
             zombieB.SetBool("Accepted", true);
        }
    }
}
