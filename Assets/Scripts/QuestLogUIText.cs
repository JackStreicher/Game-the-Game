using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLogUIText : MonoBehaviour
{
    public Text description;
    public Text itemAmount;

    [HideInInspector]
    public Quest trackedQuest = null;

    int counter = 0;


    private void FixedUpdate()
    {
        if (counter < 50)
        {
            counter++;
        }
        else
        {
            UpdateTexts();
            counter = 0;
        }

      

    }

    private void UpdateTexts()
    {
        if (trackedQuest != null)
        {
            description.text = trackedQuest.description;


            itemAmount.text = SetItemAmount(trackedQuest);

        }
    }

    private string SetItemAmount(Quest newQuest)
    {
        string goalText = "";
        List<Goal> tempGoals = newQuest.GetGoals();
        foreach (Goal goal in tempGoals)
        {
            switch (goal.goalType)
            {
                case Goal.GoalType.Collect:
                    goalText += goal.countCurrent + " " + goal.goal.name + " collected.\n";
                    break;

                case Goal.GoalType.Kill:
                    goalText += goal.countCurrent + " " + goal.goal.name + " eradicated.\n";
                    break;
            }

        }

        return goalText;
    }


}
