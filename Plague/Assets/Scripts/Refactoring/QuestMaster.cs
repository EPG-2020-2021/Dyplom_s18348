using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMaster : MonoBehaviour
{
    public static List<Quest> quests;


    void Start()
    {
        InitTestQuests();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitTestQuests()
    {
        quests = new List<Quest>();

        var quest = new Quest<StatKey>("Test_Health2", "Find item which heals at least 5 hp", QuestType.FindSpecial, StatKey.Health, 5);
        quests.Add(quest);
    }

    public static void ReleaseQuest(Quest quest)
    {
        //quests.Remove(quest);
    }
}
