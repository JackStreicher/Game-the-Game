using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public int maxMana = 100;
    public int currentMana = 100;
    public float timeToReloadManaPoints = 0.5f;




    private void Update()
    {
        //ReloadMana();
        if (currentMana <= maxMana)
        {
            currentMana++;
            //StartCoroutine(ReloadManaPoints());
        }
    }


    public void ReloadMana()
    {
        if (currentMana <= maxMana)
        {
            currentMana++;
            //StartCoroutine(ReloadManaPoints());
        }
    }

    public int GetCurrentMana()
    {
        return currentMana;
    }

    public void AddMana(int manaPoints)
    {
        if (maxMana > (manaPoints + currentMana))
        {
            currentMana += manaPoints;
        }
        else
        {
            currentMana = 100;
        }
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



    IEnumerator ReloadManaPoints()
    {
        for (int i = currentMana; i < maxMana;i++)
        {
            i++;
            yield return new WaitForSeconds(timeToReloadManaPoints);
            currentMana = i;
        }
               
        yield return new WaitForSeconds(0.1f);
    }
}
