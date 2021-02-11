using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quest/Quest", order = 1)]
public class Quest : ScriptableObject
{
    [SerializeField]
    public string title;
    [SerializeField]
    public string description;
    public List<Goal> goals;
    [SerializeField]
    public bool finished;
    [SerializeField]
    public bool completed;
    [SerializeField]
    public List<Item> itemReward;
    [SerializeField]
    public int goldReward;
    [SerializeField]
    public List<Quest> childQuests;
    [SerializeField]
    public int experienceReward;

    [SerializeField]
    public bool isQuestAccepted;


    public string GetTitle()
    {
        return title;
    }

    public string GetDescription()
    {
        return description;
    }

    public List<Item> GetItemReward()
    {
        return itemReward;
    }
    public int GetGoldReward()
    {
        return goldReward;
    }

    public Quest GetChildQuest(int pos)
    {
        return childQuests[pos];
    }
    public Quest GetFirstChildQuest()
    {
        return childQuests[0];
    }

    public bool GetIfFinished()
    {
        return finished;
    }

    public List<Goal> GetGoals()
    {
        return goals;
        
    }
    public int GetXP()
    {
        return experienceReward;
    }

    public void ResetQuest() {

        finished = false;
        for (int i = 0; i < goals.Count; i++)
        {
            goals[i].ResetGoal();
        }
    }
    public void CheckQuestStatus()
    {
        bool allFinished = false;
        for (int i= 0; i< goals.Count; i++)
        {
            if (goals[i].completed)
            {
                allFinished = true;
                
            }
            else
            {
                allFinished = false;
            }
        }

        if (allFinished)
        {

            finished = true;
            Debug.Log("Quest " + title + " has been finished! Find the Questgiver to complete it");
            
            

        }

        
       
    }


    public List<GameObject> GetQuestGoalItems()
    {
        List<GameObject> goalItems = new List<GameObject>();

        for (int i = 0; i < goals.Count; i++)
        {
            var currentGoal = goals[i].goal;
            if (currentGoal != null)
            {
                goalItems.Add(goals[i].goal);
            }
            
        }

        if (goalItems.Count == 0)
        {
            return null;
        }
        else
        {
            return goalItems;
        }

    }


    public void CompleteQuest()
    {
        if (finished)
        {        
            
            if(GameObject.Find("Questlog").GetComponent<Questlog>().GrantRewards(goldReward, experienceReward, itemReward, this, false))
            {
                GameObject.Find("Questlog").GetComponent<Questlog>().RemoveQuestFromLog(this, true);
            }
        }
    }
}
