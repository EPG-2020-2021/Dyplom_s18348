using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : Selectable
{
    public GameObject infoPanel;
    public ItemSlot slot;

    [SerializeField]
    private TextMeshProUGUI _name;
    [SerializeField]
    private TextMeshProUGUI _description;
    [SerializeField]
    private TextMeshProUGUI _stats;

    void LateUpdate()
    {
        if (slot.item && IsHighlighted() && !infoPanel.activeSelf)
        {
            infoPanel.SetActive(true);
        }
        else if (!IsHighlighted())
        {
            infoPanel.SetActive(false);
        }
    }


    public void Fill(Object item)
    {
        Clean();

        _name.text = item.name;
        _description.text = item.description;

        var stats = item.GetComponentsInChildren<Stat>();

        foreach (var stat in stats)
        {
            _stats.text += $"- {stat.statKey.ToString()}: {stat.value}\n";
        }
    }
    public void Clean()
    {
        _name.text = "";
        _description.text = "";
        _stats.text = "";
    }
}
