using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questlog : MonoBehaviour
{
    [SerializeField]
    private List<Quest> questList = new List<Quest>();

    private Stats playerStats;

    public InventoryManager playerInventory;
   

    public UpdateUIQuestList uiQuestList;
    public GlobalQuestList globalQuestList;

    int counter = 0;

    public void Start()
    {
        //Required the GameObject called "Player" to have the Stats script attached
        playerStats = GameObject.Find("Player").GetComponent<Stats>();
        //uiQuestList = GameObject.Find("QuestlogContent").GetComponent<UpdateUIQuestList>();

        UpdateLocalQuestlist();
    }


    private void FixedUpdate()
    {
        if (counter < 50)
        {
            counter++;
        }
        else
        {
            UpdateLocalQuestlist();
            counter = 0;
        }



    }

    private void UpdateLocalQuestlist()
    {

        List<Quest> newList = new List<Quest>();

        foreach (Quest quest in globalQuestList.globalQuestList)
        {
            if (!quest.finished && quest.isQuestAccepted)
            {
                newList.Add(quest);
            }
        }
        //override
        questList = newList;
    }


    public void CheckAddProgress(GameObject possibleGoal)
    {
       

        //Quest handling
        for (int i =0; i < questList.Count; i++)
        {

           
            var currentQuestGoals = questList[i].GetGoals();
            //Goal handling
            for (int j = 0; j < questList[i].GetGoals().Count; j++)
            {
                
                var currentGoal = questList[i].GetGoals()[j];
               
                //Checks if the item/monster  we just picked up/ destroyed contains the string we need for our goal
                if (possibleGoal.name.Contains(currentGoal.goal.name) && currentGoal.goalType != Goal.GoalType.Find)
                {                    

                    currentGoal.QuestAddProgress(1);
                    questList[i].CheckQuestStatus();
                    break;

                }

                //Case: When the Goal ist a Find - Find Goals should have no GameOBject as a goal, but corrdinates
                if (possibleGoal == null && currentGoal.goalType == Goal.GoalType.Find)
                {
                    currentGoal.completed = true;
                    questList[i].CheckQuestStatus();
                    break;
                }

            }

        }
        UpdateLocalQuestlist();
    }

    public void GrantRewards(int gold, int xP, List<Item> items, Quest quest, bool resetQuest)
    {
        bool successful = false;

        if (items.Count >= 0 && items != null)
        {

            foreach (var newItem in items)
            {
                if (playerInventory.AddItem(newItem, 1))
                {
                    //dezentrale completion
                    quest.completed = true;
                    successful = true;
                }
                else
                {
                    successful = false;
                    Debug.Log("You must make space in your inventory before you can complete this quest");
                    break;
                }
            }
        }
        else
        {
            successful = true;
        }

        if (successful)
        {
            playerStats.gold += gold;
            playerStats.AddExperience(xP);
            RemoveQuestFromLog(quest, resetQuest);
        }
    }

    public void RemoveQuestFromLog(Quest quest, bool resetQuest)
    {

        if (resetQuest)
        {
            quest.ResetQuest();
        }

        questList.Remove(quest);
        quest.isQuestAccepted = false;

        UpdateLocalQuestlist();
        
    }

    public void AddQuest(Quest newQuest)
    {
        //questList.Add(newQuest);
        uiQuestList.AddToUI(newQuest);
        newQuest.isQuestAccepted = true;

        UpdateLocalQuestlist();
    }

    public List<Quest> GetQuestList()
    {
        return questList;
    }



    
}
