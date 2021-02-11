using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestGoal", menuName = "ScriptableObjects/Quest/QuestGoal", order = 2)]
public class Goal : ScriptableObject
{

  
    public enum GoalType
    {
        Collect,
        Kill,        
        Find,
        Craft
    }

    public GoalType goalType;
    public int countRequired;
    public int countCurrent;
    public bool completed;
    public GameObject goal;
    public Vector3 coordinate;

    private GameObject findGoal;
    private bool spawnedTarget = false;

    public void OnValidate()
    {
        if(goalType == GoalType.Find && !spawnedTarget)
        {
            Instantiate(findGoal, coordinate, Quaternion.identity);
            spawnedTarget = true;
        }
    }
    public virtual void QuestAddProgress(int amount)
    {

            countCurrent += amount;

            countCurrent = Mathf.Clamp(countCurrent, 0, countRequired);

            if (!completed)
            {
                if (countCurrent >= countRequired)
                {
                    completed = true;
                    
                }

            }
        
    }

    public void ResetGoal()
    {
        countCurrent = 0;
        spawnedTarget = false;
        completed = false;
    }



}
