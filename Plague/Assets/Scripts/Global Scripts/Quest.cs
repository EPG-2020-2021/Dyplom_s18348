using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class Quest : MonoBehaviour
{
    [HideInInspector]
    public string key;

    public string name;

    List<Quest> ListToUnlock = new List<Quest>();

    public bool itemSearching = false;
    public bool actionsCompliting = false;

    public string questDescription = null;

    private bool isDone;

    private bool unlocked = false;

    public Item questItem;


    void Awake()
    {
        //key = "Test quest";
        QuestSave save = new QuestSave();
        //Save();
    }

    void Start()
    {
        LanguageManager.QuestTranslation(gameObject.GetComponent<Quest>());

        if(itemSearching)
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

    //---------Getters--------------

    public string GetQuestDescription()
    {
        return questDescription;
    }

    public bool isComplited()
    {
        return isDone;
    }



    
}

public class QuestSave
    {
    [HideInInspector]
        public string key = "";

        public string name = "";
        public string questDescription = "";
         
    }
