using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Creature> creatures;
    public List<Quest> quests;

    public List<Quest> complitedQuests;


    private void Awake()
    {

    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void EndQuest(Quest quest)
    {
        complitedQuests.Add(quest);
    }
}
