using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

public class MonsterAI : MonoBehaviour
{
    public Animator animator;
    public int SerachTime;
    private Vector3 idlePosition;
    public float speed;
    
    enum MonsterState
    {
        Idle, Approaching, Attacking, SearchingLostPlayer, ReturningToIdlePosition
    }
    
    private GameObject player;
    private NavMeshAgent agent;
    private bool isInSight;
    private MonsterState mState = MonsterState.Idle;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        idlePosition = transform.position;
    }
    
    private void FixedUpdate()
    {
        if (isInSight)
        {
            if (agent.hasPath)
            {
                if (Vector3.Distance(transform.position, player.transform.position) >= 1)
                {
                    mState = MonsterState.Attacking;
                }
            }
            else
            {
                mState = MonsterState.Approaching;
                SelectTarget();
            }
            
        }
        else
        {
            mState = MonsterState.SearchingLostPlayer;
        }
        
        switch(mState)
        {
            case MonsterState.Idle:
                Idle();
                break;
            case MonsterState.Attacking:
                StartAttacking();
                break;
        }
    }
    
    private void StopWalking()
    {
        agent.SetDestination(transform.position);
    }

    private void Idle()
    {
        Random rand = new Random();
        Quaternion rot = Quaternion.Euler(Mathf.Deg2Rad * rand.Next(0, 360), Mathf.Deg2Rad * rand.Next(0, 360), Mathf.Deg2Rad * rand.Next(0, 360));
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, speed * Time.deltaTime);
    }
    
    private void StartAttacking()
    {
        
    }

    private void ReturnToIdlePos()
    {
        agent.SetDestination(idlePosition);
    }
    
    private void SearchLostPlayer()
    {
        Random rand = new Random();
        agent.SetDestination(transform.position + new Vector3(rand.Next(0, 15), rand.Next(0, 15), rand.Next(0, 15)));
    }
    
    private void SelectTarget()
    {
        agent.SetDestination(player.transform.position);
    }
    
    public void SetPlayerVisible(bool isVisible)
    {
        isInSight = isVisible;
        if (isVisible)
        {
            mState = MonsterState.SearchingLostPlayer;
            StartCoroutine(SearchPlayer());
        }
    }

    public IEnumerator SearchPlayer()
    {
        yield return new WaitForSeconds(SerachTime);
        ReturnToIdlePos();
        mState = MonsterState.ReturningToIdlePosition;
    }
    
}
