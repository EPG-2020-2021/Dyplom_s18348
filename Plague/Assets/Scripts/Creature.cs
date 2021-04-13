using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public string Name;
    string type;

    
    public List<Quest> myQuests;
    
    
    void Start()
    {
        type = gameObject.GetComponent<DropDown>().GetType();
        Debug.Log(type);
    }


    void Update()
    {
        
    }

    public void publishQuest(params Quest[] quests)
    {
        foreach (Quest quest in quests)
        {
            //************
            //Some notifications of new quests
            //************


            myQuests.Add(quest);
        }
    }
}
