using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestUnit : MonoBehaviour
{
    public GameObject nameObject;
    public TextMeshProUGUI name;

    public GameObject applyBtn;
    public GameObject returnBtn;

    QuestOld quest;

    private void Start()
    {
        name = nameObject.GetComponent<TextMeshProUGUI>();
        
    }

    public void applyButton()
    {
        quest.pickQuest();
        applyBtn.SetActive(false);
        returnBtn.SetActive(true);
    }

    public void returnButton()
    {
        if (quest.returnQuest())
        {
            gameObject.SetActive(false);
        }
        else
        {
            print("You cant return this quest");
        }
    }

    // -------- setters ----------

    public void setQuest(QuestOld quest)
    {
        Debug.Log(quest.name);
        this.quest = quest;
    }

}
