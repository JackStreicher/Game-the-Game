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
    public float armor;
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
            if (damage > armor)
            {
                hitpoints +=  armor - damage;
                Debug.Log("Shot damage: " + (armor - damage));
            }
            else
            {
                hitpoints -= (baseHitpoints / 100); //1%
                Debug.Log("Shot damage: " + (baseHitpoints / 100));
            }
            
            
            SendMessageUpwards("SetTargetAndEnterCombat", player.transform.gameObject);
            hitpoints = Mathf.Clamp(hitpoints, 0, Mathf.Infinity);

            if (hitpoints == 0)
            {
                //Execute Death Logic

                if (transform.GetComponent<ItemDrop>() != null)
                {
                    transform.GetComponent<ItemDrop>().DropItems();
                }

                if (player != null && !isDead)
                {
                    //Debug.Log("Grant XP " + GrantXP());
                    player.AddExperience(GrantXP());

                    

                    //Death();
                }
                //Has to die even if there is no Player script given
                else if (!isDead)
                {
                    
                    //Death();
                }

                isDead = true;
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
        //Remover.CheckAndRemove(this.transform.gameObject);
        StartCoroutine(Remover.DelayAndRemove(this.transform.gameObject, 1500));
        var npcAnimator = transform.GetComponent<Animator>();
        if (npcAnimator != null)
        {
            npcAnimator.SetBool("Dead", true);
        }

        var characterController = GetComponent<CharacterController>();
        if (characterController != null)
        {
            characterController.radius = 0.0001f;
            characterController.height = 0.0001f;
            characterController.skinWidth = 0.0001f;
        }

    }


    public void Heal(float amount)
    {
        hitpoints += amount;
        hitpoints = Mathf.Clamp(hitpoints, 0, baseHitpoints);
    }


}
