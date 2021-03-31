﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class Quest : MonoBehaviour
{
    QuestManager questManager;

    //[HideInInspector]
    public string key;

    public string name;
    string questOwnersType;
    public string questOwnersName;

    List<Quest> ListToUnlock = new List<Quest>();

    public bool itemSearching = false;
    public bool actionsCompliting = false;

    public string questDescription = null;

    private bool isDone;
    private bool isItemFounded;
    private bool doesActionsDone;

    private bool unlocked = false;
    public bool picked = false;

    public Item questItem;
    public Item placeForItem;


    void Awake()
    {
        isItemFounded = !itemSearching;
        doesActionsDone = !actionsCompliting;
        //key = "Test quest";
        QuestSave save = new QuestSave();
        //Save();
    }

    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        LanguageManager.QuestTranslation(gameObject.GetComponent<Quest>());

        questOwnersType = gameObject.GetComponent<DropDown>().GetType();

        if (itemSearching)
        {
            questItem = new Item();
        }


    }

    void Save()
    {
        QuestSave save = new QuestSave
        {
            key = this.key,
            name = "Test quest",
            questDescription = "Nothing to do. Just be yourself <3"
        };

        string json = JsonUtility.ToJson(save);

        File.WriteAllText(Application.dataPath + "/Languages/" + "English" + "/" + key + ".txt", json);
    }

    void ItemCheck()
    {
        
    }

    void UnlockCheck()
    {
        unlocked = true;
        foreach (Quest quest in ListToUnlock)
        {
            if (!quest.isComplited())
            {
                unlocked = false;
            }
        }

        if (unlocked)
        {
            //Actions to publish this current quest;

        }

    }

    private void FixedUpdate()
    {
        if (picked)
        {
            if (itemSearching)
            {
                if (placeForItem.gameObject == questItem.gameObject)
                {
                    isItemFounded = true;
                }
            }
            if (isItemFounded && doesActionsDone)
            {
                isDone = true;
                questManager.EndQuest(gameObject.GetComponent<Quest>());
                //Destroy(gameObject);
                gameObject.active = false;
            }
        }
    }

    //---------Getters--------------
    public bool isPicked()
    {
        return picked;
    }
    public string GetQuestDescription()
    {
        return questDescription;
    }

    public bool isComplited()
    {
        return isDone;
    }

    public bool doesActionDone()
    {
        return doesActionsDone;
    }

    //---------Setters--------------


    public void finishAction()
    {
        doesActionsDone = true;
    }
}

public class QuestSave
    {
    [HideInInspector]
        public string key = "";

        public string name = "";
        public string questDescription = "";
         
    }