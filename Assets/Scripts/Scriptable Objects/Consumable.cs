using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "ScriptableObjects/Consumable", order = 2)]
public class Consumable : Item
{

    [SerializeField]
    private string benefit;
    [SerializeField]
    private bool canHeal;   
    [SerializeField] 
    private float healingAmount;
    


    public void Heal()
    {
        //Target: Player
        //Heal Player Health
    }


    public bool CanHeal()
    {
        return canHeal;
    }

    public bool GetCanHeal()
    {
        return canHeal;
    }
   

    public string GetBeneftig()
    {
        return benefit;
    }
    public float GetHealing()
    {
        return healingAmount;
    }

    public virtual void Consume(Object stats)
    {
        if (canHeal && (stats is Stats && canHeal || stats == null))
        {
            Stats playerStats = GameObject.Find("Player").GetComponent<Stats>();
            playerStats.Heal(healingAmount);
            
            
           
        }
        if (canHeal && stats is NPCStats && canHeal)
        {
            NPCStats npcStats = (NPCStats)stats;
            npcStats.Heal(healingAmount);
           

           
        }

    }

}
