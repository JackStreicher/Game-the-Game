using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUIQuestList : MonoBehaviour
{
    
    public SimpleInventoryList questItemList;
    public GameObject buttonPrefab;
    public GlobalQuestList globalQuestList;
    Questlog questlog;

    [HideInInspector]
    public List<Quest> uiQuestList;
    private int counter = 0;

    public void Start()
    {
        questlog = GameObject.Find("Questlog").GetComponent<Questlog>();
        uiQuestList = null;
    }

    private void FixedUpdate()
    {

        //update once per second
        if (counter < 50)
        {
            counter++;
        }
        else
        {
            //do sth.
            if (uiQuestList == null || uiQuestList[0] != questlog.GetQuestList()[0] && uiQuestList.Count == questlog.GetQuestList().Count)
            {
                //erase and Update all QuestButtons
                EraseAndUpdate();
            }
            counter = 0;
        }



    }


    private void EraseAndUpdate()
    {
       

        int childCount = transform.childCount;
       for (int i = 0; i < childCount; i++)
       {
           Destroy(transform.GetChild(i));            
       }

        uiQuestList = questlog.GetQuestList();

        foreach (Quest quest in uiQuestList)
        {
            AddToUI(quest);
        }
    }

    //Update this
    
     //Call this Method everytime the Questlog Questlist needs to add a quest
     public void AddToUI(Quest quest)
     {
         GameObject newObj;

         newObj = (GameObject)Instantiate(buttonPrefab, transform);
         newObj.GetComponent<QuestOnButton>().quest = quest;
         newObj.name = quest.title;

         Text buttonText = newObj.transform.GetChild(0).GetComponent<Text>();
         buttonText.text = quest.title;
     }
    /*
     //Call this Method everytime the A Quest has been removed from the Questlog
     public void RemoveFromUI(Quest quest)
     {
         var buttontoRemove = transform.Find(quest.title);
         Destroy(buttontoRemove);
         ValidityCheck();
     }

     //Checks wether all the Quests in the UI are actually accepted
     //Change so it can handle already finsihed quests as well
     public void ValidityCheck()
     {
     }
        */
}
