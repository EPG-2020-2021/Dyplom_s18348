using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestMaster : MonoBehaviour
{
    public static List<Quest> quests;

    public GameObject questUIprefab;
    public Transform questUiholder;

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
        
        AddQuest("Test_Health_5", "Find item which heals at least 5 hp", QuestType.FindSpecial, StatKey.Health, 5);
        AddQuest("Test_Health_100", "Find item which heals at least 100 hp", QuestType.FindSpecial, StatKey.Health, 100);
        AddQuest("Test_Health_60", "Find item which heals at least 60 hp", QuestType.FindSpecial, StatKey.Health, 60);
        AddQuest("Test_Health_50", "Find item which heals at least 50 hp", QuestType.FindSpecial, StatKey.Health, 50);
        AddQuest("Test_Health_55", "Find item which heals at least 55 hp", QuestType.FindSpecial, StatKey.Health, 55);
        AddQuest("Test_Rosemary", "Find rosemary", QuestType.Find, "Rosemary");
        AddQuest("Test_Rosemary2", "Find rosemary2", QuestType.Find, "Rosemary2");
        AddQuest("Test_Rosemary3", "Find rosemary3", QuestType.Find, "Rosemary3");

        AddQuest("Booster", "Find soil", QuestType.Find, "Soil", 100);
    }

    public static void ReleaseQuest(Quest quest)
    {
        //quests.Remove(quest);
    }

    private void AddUIQuest(Quest<StatKey> quest)
    {
        print("Add quest");
        if (quest.completed)
        {
            print("No need to add quest. Completed");
            return;
        }

        var unit = Instantiate(questUIprefab, questUiholder);
        var texts = unit.GetComponentsInChildren<TextMeshProUGUI>();

        texts[0].text = quest.questName;
        texts[1].text = quest.questDescription;

        quest.uiUnit = unit;
        quest.onCompleteCallback += quest.DestroySelf;
    }

    private void AddQuest(string name, string description, QuestType type, StatKey specialParam, int specialParamCount, int exp = 0)
    {
        var quest = new Quest<StatKey>(name, description, type, specialParam, specialParamCount);
        quest.SetReward(exp);
        AddUIQuest(quest);
        quests.Add(quest);
    }
    private void AddQuest(string name, string description, QuestType type, string itemName, int exp = 0)
    {
        var quest = new Quest<StatKey>(name, description, type, itemName);
        quest.SetReward(exp);
        AddUIQuest(quest);
        quests.Add(quest);
    }

    public void DestroyUI(GameObject obj)
    {
        print("Destroy");
        Destroy(obj);
    }
}
