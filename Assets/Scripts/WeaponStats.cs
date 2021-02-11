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
    public DamageType damageType;
    public bool isAttacking;
    

    private void OnCollisionEnter(Collision collision)
    {
        if (isAttacking)
        {
            if (collision.transform.GetComponent<Stats>())
            {
                collision.transform.GetComponent<Stats>().SufferDamage((int)damage);
            }
            if (collision.transform.GetComponent<NPCStats>())
            {
                collision.transform.GetComponent<NPCStats>().SufferDamage((int)damage, null);
            }
        }
    }

}
