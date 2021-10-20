using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    QuestManager questManager;

    public string Name;
    string type;

    bool interactible = false;

    public GameObject player;
    
    public List<Quest> myQuests;

    public GameObject talkWindow;

    bool listed = false;

    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        myQuests = new List<Quest>();
        type = gameObject.GetComponent<DropDown>().GetType();

        talkWindow = GameObject.Find("Canvas").transform.Find("TalkWindowHandler").Find("Talk window").gameObject;
        talkWindow.transform.parent.gameObject.active = false;
    }

    void afterSceneLoadFinder()
    {
        if (talkWindow == null)
        {
        talkWindow = GameObject.Find("Canvas").transform.Find("TalkWindowHandler").Find("Talk window").gameObject;
            print(talkWindow);
            

        }
    }

    void FixedUpdate()
    {
        afterSceneLoadFinder();

        if (myQuests.Count > 0)
        {
            questCleaner();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && interactible)
        {
            //Talk window
            Debug.Log("Interaction with " + Name);
            if (!listed)
            {               
                openTalkWindow();
                talkWindow.GetComponent<TalkWindow>().fillPanel(myQuests);
                listed = true;
            }
            

           
        }
    }



    void questCleaner()
    {
        foreach (Quest quest in myQuests)
        {
            if (quest.isComplited())
            {
                myQuests.Remove(quest);
                break;
            }
        }
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            interactible = true;
        }



    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = null;
            interactible = false;
            talkWindow.GetComponent<TalkWindow>().cleanPanel();
            talkWindow.transform.parent.gameObject.active = false;
            listed = false;
        }

        

    }

    private void openTalkWindow()
    {
        talkWindow.transform.parent.gameObject.active = !talkWindow.transform.parent.gameObject.activeSelf;
    }


}
