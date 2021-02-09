using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public int maxMana = 100;
    public int currentMana = 100;

    public bool isPassiveRegeneration = true;

    public int passiveRegCounter = 0;
    private int passiveRegTimeInFrames = 50;
    float passiveRegAmount = 1f;

  

    private void FixedUpdate()
    {
        PassiveRegeneration();    
    }

    public void PassiveRegeneration()
    {
        if (isPassiveRegeneration) {
         
            if (passiveRegCounter < passiveRegTimeInFrames)
            {
                passiveRegCounter++;
                
            }
            else
            {
                AddMana((int)passiveRegAmount);
                passiveRegCounter = 0;
            }
        }
    }

    public void AddMana(int manaPoints)
    {            
            currentMana += manaPoints;
            currentMana = Mathf.Clamp(currentMana, 0, maxMana);
    }

    public bool CanThePlayerUseMane(int manaPoints)
    {
        if(0 >= (currentMana - manaPoints))
        {
            Debug.Log("The Player has not enought Mana for this Action");
            return false;
        }
        else
        {           
            return true;
        }
    }
}
