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
        
        AddQuest("Find health 10", "Find item which heals at least 10 hp", QuestType.FindSpecial, StatKey.Health, 5);

        AddQuest("Find rosemary", "Find rosemary", QuestType.Find, "Rosemary");

        AddQuest("Find streptomycin", "Find the cure for plague", QuestType.Find, "Streptomycin");

        AddQuest("Find soil", "It will help you with the plague someday", QuestType.Find, "Soil");
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
