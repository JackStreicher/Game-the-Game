using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.ComponentModel;

public class QuestGenerator : EditorWindow
{
    #region Goals Variables
    //Goals
    string goalName;
    Goal.GoalType goalType;
    int countRequired;
    GameObject goal;
    Vector3 coordinate;
    public int goalAmount = 1;
    bool isDrawn = false;

    List<Goal> createdGoalsList = new List<Goal>();

    private List<string> goalNames = new List<string>();
    private List<Goal.GoalType> goalTypes = new List<Goal.GoalType>();
    private List<int> countsRequired = new List<int>();
    private List<GameObject> goals = new List<GameObject>();
    private List<Vector3> coordinates = new List<Vector3>();

    #endregion


    #region Quest Variables

    private string qTitle;
    private string qDescription;
    private List<Item> qItemReward = new List<Item>();
    private Item qItemRewardSingle;
    private int qGoldReward;
    private int qExperienceReward;
    private int qRewardAmount;

    bool isGoalsFin = false;
    bool isRewardAmountSet = false;

    Vector2 scrollPosition;
    #endregion


    [MenuItem("Item Tools/Goal Creator")]
    public static void ShowWindow()
    {
        GetWindow(typeof(QuestGenerator));

    }


    public void OnGUI()
    {
        //Scrolling Start
        scrollPosition = GUILayout.BeginScrollView(scrollPosition,GUILayout.Width(position.width), GUILayout.Height(position.height));

        goalAmount = EditorGUILayout.IntField("Amount of Goals", goalAmount);


        if (GUILayout.Button("Set Goal Amount"))
        {
            //Creates the Input Fields
            for (int i = 0; i < goalAmount; i++)
            {
                //GUILayout.Label("\nGoal" + i, EditorStyles.boldLabel);
                goalNames.Add(EditorGUILayout.TextField("Name of the Goal", goalName));
                goalTypes.Add((Goal.GoalType)EditorGUILayout.EnumPopup("Goal Name", goalType));
                countsRequired.Add(EditorGUILayout.IntField("Goal Amount neded", countRequired));
                goals.Add((GameObject)EditorGUILayout.ObjectField("Object Goal (Prefab)", goal, typeof(GameObject), false));
                coordinates.Add(EditorGUILayout.Vector3Field("Corrdinates", coordinate));
            }

            isDrawn = true;
        }


        if (isDrawn)
        {

            for (int i = 0; i < goalAmount; i++)
            {
                //Draws the Input fields and we can fill them now
                GUILayout.Label("Qoal" + i, EditorStyles.boldLabel);
                goalNames[i] = EditorGUILayout.TextField("Name of the Goal", goalNames[i]);
                goalTypes[i] = (Goal.GoalType)EditorGUILayout.EnumPopup("Goal Name", goalTypes[i]);
                countsRequired[i] = EditorGUILayout.IntField("Goal Amount neded", countsRequired[i]);
                goals[i] = (GameObject)EditorGUILayout.ObjectField("Object Goal (Prefab)", goals[i], typeof(GameObject), false);
                coordinates[i] = EditorGUILayout.Vector3Field("Corrdinates", coordinates[i]);
            }
        }



        if (GUILayout.Button("Create Goals"))
        {




            for (int i = 0; i < goalAmount; i++)
            {
                //create a single goal
                Goal temp = (Goal)ScriptableObject.CreateInstance(typeof(Goal));

                //fill the in the values fo a single goal for the corresponding position of the list 
                temp.goalType = goalTypes[i];
                temp.countRequired = countsRequired[i];
                temp.goal = goals[i];
                temp.coordinate = coordinates[i];
                createdGoalsList.Add(temp);

                string assetPath;
                if (AssetDatabase.FindAssets(goalNames[i]).Length > 0 && AssetDatabase.FindAssets(goalNames[i]) != null)
                {
                    assetPath = AssetDatabase.GenerateUniqueAssetPath("Assets/Quests/Goals/" + goalNames[i] + "" + 1 + ".asset");
                }
                else
                {
                    assetPath = AssetDatabase.GenerateUniqueAssetPath("Assets/Quests/Goals/" + goalNames[i] + ".asset");
                }
               


                AssetDatabase.CreateAsset(temp, assetPath);
            }

            AssetDatabase.SaveAssets();


            //Create Goal Logi start
            isGoalsFin = true;

        }


        if (isGoalsFin)
        {

            qTitle = EditorGUILayout.TextField("Questname", qTitle);
            qDescription = EditorGUILayout.TextField("Description", qDescription);
            qGoldReward = EditorGUILayout.IntField("Gold reward", qGoldReward);
            qExperienceReward = EditorGUILayout.IntField("XP reward", qExperienceReward);
            qRewardAmount = EditorGUILayout.IntField("Item reward amount", qRewardAmount);

            if (GUILayout.Button("Set Reward Armount"))
            {
                for (int j = 0; j < qRewardAmount; j++)
                {
                    qItemReward.Add((Item)EditorGUILayout.ObjectField("Item reward (Prefab)", qItemRewardSingle, typeof(Item), false));

                }

                isRewardAmountSet = true;
            }

            if (isRewardAmountSet)
            {
                for (int i = 0; i < qRewardAmount; i++)
                {
                    qItemReward[i] = (Item)EditorGUILayout.ObjectField("Item reward", qItemReward[i], typeof(Item), false);
                }
            }
          
        }

    


        if (GUILayout.Button("Create Quest"))
        {

            //in for
            Quest tempQuest = (Quest)ScriptableObject.CreateInstance(typeof(Quest));

            tempQuest.title = qTitle;
            tempQuest.description = qDescription;
            tempQuest.experienceReward = qExperienceReward;
            tempQuest.goldReward = qGoldReward;

            
                tempQuest.goals = new List<Goal>();
                tempQuest.goals = createdGoalsList;



            tempQuest.itemReward = new List<Item>();

            for (int x = 0; x < qRewardAmount; x++)
            {                
                tempQuest.itemReward.Add(qItemReward[x]);
            }
            




            string assetPathQuest = "Assets/Quests/" + qTitle + ".asset";
            
            AssetDatabase.CreateAsset(tempQuest, assetPathQuest);
            AssetDatabase.SaveAssets();

            this.Close();
        }

        //End Scrolling
        GUILayout.EndScrollView();
    
    }

   

}
