using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class SetTextField : MonoBehaviour
{


    // Update is called once per frame
    public void SetText(string textFieldName, string newText)
    {
       Text textField = GameObject.Find(textFieldName).transform.GetComponent<Text>();
        textField.text = newText;
    }

    
    public void SetQuestTextDescription(string textFieldName, Quest quest)
    {
        Text textField = GameObject.Find(textFieldName).transform.GetComponent<Text>();
        textField.text = quest.description;
    }


    public void SetCurrentQuestItems(string textFieldName, Quest quest)
    {
        Text textField = GameObject.Find(textFieldName).transform.GetComponent<Text>();

        string goalText = "";
        List<Goal> tempGoals = quest.GetGoals();
        foreach (Goal goal in tempGoals)
        {
            switch (goal.goalType)
            {
                case Goal.GoalType.Collect:
                    goalText +=  goal.countCurrent + " " + goal.goal.name + " collected.\n";
                    break;

                case Goal.GoalType.Kill:
                    goalText += goal.countCurrent + " " + goal.goal.name + " eradicated.\n";
                    break;
            }

        }

        textField.text = goalText;
        //List<GameObject> questGoals;

    }
}
