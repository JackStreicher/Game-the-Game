using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helth : MonoBehaviour
{
    public string gOname;
    [Header("Helth and damage Vars")]
    public static int health;
    public int HP;
    public int damage;
    
    //if player then true
    public bool isPlayer;
    public bool isHit;

    private void Start()
    {

        health = HP;

        Debug.Log(health);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (isHit)
        {
            DamageCalc();
        }
        if (DamageThePlayer.plDamage == true)
        {
            health -= DamageThePlayer.plDamageCalc;
        }
     
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name.Contains(gOname))
        {
            Debug.Log("Hit");
            isHit = true;
        }
    }
    public void DamageCalc()
    {
        if (!isPlayer)
        {
            health -= damage;
            Debug.Log(health);
            isHit = false;

        }

    }
}
