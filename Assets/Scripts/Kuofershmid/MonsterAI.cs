using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class MonsterAI : MonoBehaviour
{
    public Animator animator;
    public float speed;
    
    enum MonsterState
    {
        Idle, Approaching, Attacking
    }
    
    private GameObject player;
    private MonsterState mState = MonsterState.Idle;
    private List<Vector3> wayPoints;

    private bool isTargetReached = true;
    
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        wayPoints = new List<Vector3>();
    }
    
    private void FixedUpdate()
    {
        switch(mState)
        {
            case MonsterState.Idle:
                Idle();
                break;
            case MonsterState.Approaching:
                ApproachPlayer();
                break;
            case MonsterState.Attacking:
                StartAttacking();
                break;
        }



    }
    
    private void Idle()
    {
        Random rand = new Random();
        Quaternion rot = Quaternion.Euler(Mathf.Deg2Rad * rand.Next(0, 360), Mathf.Deg2Rad * rand.Next(0, 360), Mathf.Deg2Rad * rand.Next(0, 360));
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, speed * Time.deltaTime);
    }

    private void ApproachPlayer()
    {
        if (wayPoints.Count > 0)
        {
            Vector3 pos = wayPoints[0];
            wayPoints.Remove(wayPoints[0]);
            Move(pos);
        }
        
        if (Vector3.Distance(transform.position, player.transform.position) <= 1)
        {
            wayPoints.Clear();
            mState = MonsterState.Attacking;
        }
    }
    
    private void StartAttacking()
    {
        if (Vector3.Distance(transform.position, player.transform.position) >= 5)
        {
            mState = MonsterState.Approaching;
            StartCoroutine(GetWayPoints());
        }
    }

    public void SetPlayerVisible(bool isVisible)
    {
        if (isVisible) mState = MonsterState.Approaching;
        StartCoroutine(GetWayPoints());
    }
    
    public IEnumerator GetWayPoints()
    {
        while (mState == MonsterState.Approaching)
        {
            wayPoints.Add(player.transform.position);
            yield return new WaitForSeconds(0.1f);
        }
    }
    
    public void Move(Vector3 pos)
    {
        if (isTargetReached)
        {
            isTargetReached = false;
            StartCoroutine(MoveToPosition(pos));
        }
    }
    
    public IEnumerator MoveToPosition(Vector3 pos)
    {
        bool reachedTarget = false;
        while (!reachedTarget)
        {
            transform.position -= (new Vector3(transform.position.x, transform.position.y, transform.position.z) - pos).normalized;
            yield return new WaitForFixedUpdate();
            if (Vector3.Distance(transform.position, pos) <= 5)
            {
                reachedTarget = true;
                isTargetReached = true;
            }
        }
        
    }
    
}
