using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helth : MonoBehaviour
{
    public string playerWeponName;
    [Header("Helth and damage Vars")]
    public int health;
    public int damage;
    
    //if player then true
    public bool isPlayer;
    bool isHit;

    
    private void Start()
    {
        Debug.Log(health);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!isPlayer && isHit)
        {
            EnemyDamageCalc();
        }

        if (DamageThePlayer.plDamage == true)
        {
            Debug.Log("test");
            PlayerDamageCal();
        }
     
    }

    private void OnCollisionEnter(Collision col)
    {
        //collison with the attack of the player
        if (col.gameObject.name.Contains(playerWeponName))
        {
            Debug.Log("Hit");
            isHit = true;
        }
    }

    //Enemy damage is calculated 
    public void EnemyDamageCalc()
    {
        //check that it is not the player and then the damage calc
        if (!isPlayer)
        {
            health -= damage;
            Debug.Log(health);
            isHit = false;

        }

        //if the health is less then or = to 0 the obj is Destroyed 
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }

    }

    //if the player gets hit by the enemy
    public void PlayerDamageCal()
    {
        //sets the damage bool to false
        DamageThePlayer.plDamage = false;
        
        //damage is addet 
        health -= DamageThePlayer.plDamageCalc;

        if(health <= 0)
        {
            GameObject pl = GameObject.FindWithTag("move");

            pl.SetActive(false);
        }

        //test 
        Debug.Log(health);
    }
}
