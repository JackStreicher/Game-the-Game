using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Armor", menuName = "ScriptableObjects/Armor", order = 3)]
public class Armor : Item
{


    public int armorValue;
    public int healthModifier;
    public int staminaModifier;
    private bool statsApplied;

    private Stats playerStats;

    public void Start()
    {   
        playerStats = GameObject.Find("Player").GetComponent<Stats>();
        
    }


    public override void ApplyStats()
    {


        if (playerStats == null)
        {
            playerStats = GameObject.Find("Player").GetComponent<Stats>();
        }
        if (!statsApplied) {
            playerStats.IncreaseArmor(armorValue);
            playerStats.AddHealth (healthModifier);
            playerStats.AddStamina(staminaModifier);
            statsApplied = true;
        }
    }


    public override void RemoveStats()
    {
        if (statsApplied)
        {
            playerStats.IncreaseArmor(-armorValue);
            playerStats.AddHealth(-healthModifier);
            playerStats.AddStamina(-staminaModifier);
            statsApplied = false;
        }
    }
}
