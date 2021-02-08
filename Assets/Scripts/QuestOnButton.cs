using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestOnButton : MonoBehaviour
{
    [HideInInspector]
    public Quest quest;
    QuestLogUIText uiText;

    public void Start()
    {
        uiText = GameObject.Find("QuestLogPanel").GetComponent<QuestLogUIText>();
    }

    public void SetQuestAsTracked()
    {
        uiText.trackedQuest = quest;
    }
}
