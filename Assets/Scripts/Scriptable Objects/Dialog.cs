using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EmptyDialog", menuName = "ScriptableObjects/Dialog", order = 1)]
public class Dialog : ScriptableObject
{
   public string npcName;
   public List<string> dialogLines = new List<string>();
   public string awaitingQuestCompletion;
   public Quest quest;
   //public bool isQuestAccepted = false;

}
