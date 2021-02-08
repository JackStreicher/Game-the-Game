using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MartinMove : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject ziel;
    void Start()
    {
        agent.SetDestination(ziel.transform.position);
    }

    // Update is called once per frame
    void Update()
    {


    }
}
