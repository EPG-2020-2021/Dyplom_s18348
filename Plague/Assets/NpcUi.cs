using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NpcUi : MonoBehaviour
{
    public NPCScript npc;
    public GameObject textPanel;


    public void Show()
    {
        if (textPanel.GetComponentInChildren<TextMeshProUGUI>().text.Equals(""))
        {
            return;
        }
        UpdateStats();
        textPanel.gameObject.SetActive(true);
    }

    public void Hide()
    {
        textPanel.gameObject.SetActive(false);
    }

    public void UpdateStats()
    {
        //textStats.text = npc.characterStats.GetStatsString();
    }
}
