using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TalkWindow : MonoBehaviour
{
    GameObject Scroll;
    public GameObject QuestUnitPrefab;


    GameObject QuestListPanel;

    public GameObject QuestUnit;
    public TextMeshProUGUI QuestName;
    GameObject ApplyButton;
    GameObject ReturnButton;


  

    // Start is called before the first frame update
    void Start()
    {
        Scroll = GameObject.FindGameObjectWithTag("Scroll");
        QuestListPanel = GameObject.FindGameObjectWithTag("Quest List Panel");

        QuestUnitPrefab = (GameObject)Resources.Load("Prefabs/Quest Unit", typeof(GameObject));

        
    }

    public void fillPanel(List<Quest> quests)
    {
        foreach (Quest quest in quests)
        {
            if (!quest.isComplited())
            {
                QuestUnit = Instantiate(QuestUnitPrefab);
                QuestUnit.GetComponent<QuestUnit>().setQuest(quest);
                QuestName = QuestUnit.transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>();
                ApplyButton = QuestUnit.transform.Find("Apply Button").gameObject;
                ReturnButton = QuestUnit.transform.Find("Return Button").gameObject;

                if (quest.isPicked())
                {
                    ApplyButton.SetActive(false);
                    ReturnButton.SetActive(true);
                }

                QuestName.text = quest.name;

                QuestUnit.transform.SetParent(QuestListPanel.transform, false);
            }
            
        }
    }

    public void cleanPanel()
    {
        //List<GameObject> children = QuestListPanel.transform.get


        foreach (Transform child in QuestListPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

    }

    
}
