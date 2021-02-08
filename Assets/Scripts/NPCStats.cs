using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStats : MonoBehaviour
{

    public enum NPCTag
    {
        Friendly,
        Enemy,
        Neutral
    }

    public Animator anim;
    public NPCTag npcTag;
    public string npcName;
    public float baseHitpoints;
    public float hitpoints;
    public int level;
    //Ordinary enemies: 1, elites: 2, unquies: 3, boss: 4, god: 6;
    public int difficulty = 1;

    private int xpGranted = 0;

    private int xpBase = 10;

    private bool isDead;

    public void Start()
    {
        //Set XP granted by killing this NPC
        xpGranted = xpBase * (int)Mathf.Pow((float)level, (float)difficulty);

        //Set Tag
        transform.gameObject.tag = npcTag.ToString();

        transform.gameObject.name = npcName;
    }


    public int GrantXP()
    {
        return xpGranted;
    }

    public void SufferDamage(float damage, Stats player)
    {
        if (!isDead)
        {
            
            hitpoints -= damage;

            hitpoints = Mathf.Clamp(hitpoints, 0, Mathf.Infinity);

            if (hitpoints == 0)
            {
                //Execute Death Logic

                if (transform.GetComponent<ItemDrop>() != null)
                {
                    transform.GetComponent<ItemDrop>().DropItems();
                }

                if (player != null)
                {
                    Debug.Log("Grant XP " + GrantXP());
                    player.AddExperience(GrantXP());
                    
                    Death();
                }
                //Has to die even if there is no Player script given
                else
                {
                    
                    Death();
                }
            }
        }
    }
    
    /// <summary>
    /// Has to be edited once we have animations
    /// </summary>
    private void Death()
    {
        //Play death animation
        //StartCoroutine(Remover.DelayAndRemove(this.transform.gameobject, 200))
        isDead = true;
        Remover.CheckAndRemove(this.transform.gameObject);
    }


    public void Heal(float amount)
    {
        hitpoints += amount;
        hitpoints = Mathf.Clamp(hitpoints, 0, baseHitpoints);
    }


}
