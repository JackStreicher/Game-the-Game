using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MartinMove : MonoBehaviour
{
    public NavMeshAgent agent;
    public Questlog ql;
    public GameObject ziel;
    private bool questRunning;
    private bool walking;
    void Start()
    {
        //agent.SetDestination(ziel.transform.position);
    }

    void Update()
    {
        for (int i = 0; i < ql.GetQuestList().Count + 1; i++)
        {
            if (ql.GetQuestList()[i].title.Contains("Move Move Move!!!")) //Durchsucht die Questliste nach einer Quest mit dem bestimmten Titel
            {
                questRunning = true;
                break;
            }
        }
        if (questRunning)
        {
            agent.SetDestination(ziel.transform.position);
            walking = true;
        }
    }
}
