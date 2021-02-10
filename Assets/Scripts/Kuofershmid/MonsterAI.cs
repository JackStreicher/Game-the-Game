using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MonsterAI : MonoBehaviour
{
    private GameObject Player;

    public void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    
    public void FixedUpdate()
    {
        Debug.Log("Player is at " + Player.transform.position);
        transform.position = Player.transform.position;
    }
}
