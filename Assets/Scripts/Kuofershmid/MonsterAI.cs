using System;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    private GameObject player;
    public NavMeshAgent agent;
    private Collider vision;
    private bool isInSight;
    
    public void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        vision = GameObject.FindWithTag("VisionCone").gameObject.GetComponent<MeshCollider>();
    }
    
    public void FixedUpdate()
    {
        if (IsPlayerVisible())
        {
            SelectTarget();
        }
    }
    
    public void SelectTarget()
    {
        agent.SetDestination(player.transform.position);
    }

    public bool IsPlayerVisible()
    {
        if(isInSight)
        {
            //Debug.Log("I can See you\n-The enemy");
            return true;
        }
        else
        {
            //Debug.Log("Cant see player");
            return false;
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("Player")) isInSight = true;
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.transform.CompareTag("Player")) isInSight = false;
    }
}
