using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Quest : MonoBehaviour
{
    GameObject player;

    QuestManager questManager;

    //[HideInInspector]
    public string key;

    public string name;
    string questOwnersType;
    public string questOwnersName;
    public Creature owner;

    public List<Quest> ListToUnlock = new List<Quest>();

    public bool itemSearching = false;
    public bool actionsCompliting = false;

    public string questDescription = null;

    private bool isDone;
    private bool isItemFounded;
    private bool doesActionsDone;

    private bool published = false;
    public bool unlocked = false;
    public bool picked = false;

    public bool onlyWhenPicked = false;

    public CraftItem placeForItem;
    public string FindName = "";
    public float FindQuality = 0f;
    public List<string> FindFeatures;

    [Header("Reward")]
    public float reward_exp = 0f;
    public GameObject reward_item;
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
        player = GameObject.FindGameObjectWithTag("Player");

        questManager = FindObjectOfType<QuestManager>();
        LanguageManager.QuestTranslation(gameObject.GetComponent<Quest>());

        questOwnersType = gameObject.GetComponent<DropDown>().GetType();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (unlocked)
        {
            owner.publishQuest(this);
            published = true;

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

        if (unlocked && !published)
        {
            owner.publishQuest(this);
            print("Trhere is a new available quest");
            published = true;

        }

    }

    private void FixedUpdate()
    {
        if (!picked)
        {
            UnlockCheck();
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

    public void pickQuest()
    {
        picked = true;
    }

    public bool returnQuest()
    {
        if (itemSearching &&
            questManager.checkItemName(placeForItem, FindName) &&
            questManager.checkItemQuality(placeForItem, FindQuality) &&
            questManager.checkItemFeatures(placeForItem, FindFeatures))
        {
            return false;
        }
        else {
            isItemFounded = true;
        }
        if (actionsCompliting && !doesActionsDone)
        {
            return false;
        }

        isDone = true;
        questManager.EndQuest(gameObject.GetComponent<Quest>());
        InventoryOLD.instance.Remove(placeForItem);
        gameObject.active = false;

        questManager.giveReward(reward_exp, reward_item);
        return true;
    }
    public void finishAction()
    {
        if (onlyWhenPicked && isPicked())
        {
            doesActionsDone = true;
        }
        else if(!onlyWhenPicked){
            doesActionsDone = true;
        }
        
    }
}

public class QuestSave
    {
    [HideInInspector]
        public string key = "";

        public string name = "";
        public string questDescription = "";
         
    }
