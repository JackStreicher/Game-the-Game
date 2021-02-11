using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerDistance : MonoBehaviour
{
    public Goal goal;
    public Quest quest;
    private GameObject player;
    public float distanceUntilTrigger;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (goal != null && !goal.completed)
        {
            var dist = Vector3.Distance(this.transform.position, player.transform.position);
            if (dist <= distanceUntilTrigger)
            {
                goal.completed = true;
                quest.CheckQuestStatus();
            }
        }
    }
}
