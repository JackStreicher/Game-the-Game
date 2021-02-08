using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GlobalQuestList", menuName = "ScriptableObjects/Quest/GlobalQuestList", order = 1)]
public class GlobalQuestList : ScriptableObject
{
    public List<Quest> globalQuestList;
}
