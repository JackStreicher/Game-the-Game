﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWeapon : MonoBehaviour
{

    public GameObject weapon;
    public WeaponStats wStats;
    public GameObject weaponSlot;
    // Start is called before the first frame update
    void Start()
    {
        if (weapon != null && weaponSlot != null)
        {
            wStats = weapon.GetComponent<WeaponStats>();
            wStats.wielder = transform.gameObject;
            var weaponInstance = Instantiate(weapon, weaponSlot.transform);
            
            wStats.isAttacking = false;
        }
    }


    public void SetIsAttacking(bool state)
    {
        wStats.isAttacking = state;
    }

   
}
