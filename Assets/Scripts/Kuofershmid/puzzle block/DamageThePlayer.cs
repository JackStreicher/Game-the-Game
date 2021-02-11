using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageThePlayer : MonoBehaviour
{
    public int damageThePl;

    //is the damage that is addet in Helth
    public static int plDamageCalc;
   
    //tag from the hit obj
    public string tagName;

    bool isDamaged = false;    
    public static bool plDamage = false;

    public void Start()
    {
        //sets the add damage = with the entert value
        plDamageCalc = damageThePl;
    }

    //looks if the player is hit by the Wepon/Trap
    private void OnTriggerEnter(Collider other)
    {
        //checks if the tag is = to the entert damage tag
        if (other.tag == tagName)
        {
            //sets the static bool to true
            isDamaged = true;
            plDamage = isDamaged;
        }
    }
}
