using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{

    public enum DamageType
    {
        Piercing,
        Bludgeoning,
        Cutting,
        Frost,
        Fire,
        Arcane,
        Tech
    }

    public float damage;
    public float speed;
    public DamageType damageType;
    public bool isAttacking;
    public GameObject wielder;
    

    private void OnCollisionEnter(Collision collision)
    {
        
        if (isAttacking)
        {
            
            if (collision.transform.GetComponent<Stats>() != null && collision.gameObject.name != wielder.name)
            {
                collision.transform.GetComponent<Stats>().SufferDamage((int)damage);
                //Debug.Log("Hitting Player for " + damage);
            }
            if (collision.transform.GetComponent<NPCStats>() != null && collision.gameObject.name != wielder.name && collision.gameObject.tag != wielder.tag)
            {
                collision.transform.GetComponent<NPCStats>().SufferDamage((int)damage, null);
            }
        }
    }

    
}
