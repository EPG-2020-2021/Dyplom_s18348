using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMaster : MonoBehaviour
{
    public List<Quest> quests;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitTestQuests()
    {
        var quest = new Quest<StatKey>(QuestType.BringSpecial, StatKey.Health, 5);
        quests.Add(quest);
    }
}
