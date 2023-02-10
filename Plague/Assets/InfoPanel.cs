using System;
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

    public InfoPanel()
    {
    }

    public void Clean()
    {
        this._name.text = "";
        this._description.text = "";
        this._stats.text = "";
    }

    public void Fill(Object item)
    {
        this.Clean();
        this._name.text = item.name;
        this._description.text = item.description;
        Stat[] componentsInChildren = item.GetComponentsInChildren<Stat>();
        for (int i = 0; i < (int)componentsInChildren.Length; i++)
        {
            Stat stat = componentsInChildren[i];
            if (!stat.statKey.Equals(StatKey.Plague) || stat.@value < 0f)
            {
                TextMeshProUGUI textMeshProUGUI = this._stats;
                textMeshProUGUI.text = String.Concat(textMeshProUGUI.text, String.Format("- {0}: {1}\n", (object)stat.statKey.ToString(), stat.@value));
            }
        }
        TextMeshProUGUI textMeshProUGUI1 = this._stats;
        textMeshProUGUI1.text = String.Concat(textMeshProUGUI1.text, "\nCost: ", item.cost.ToString(), "\n");
    }

    private void FixedUpdate()
    {
        if (this.slot.item && base.IsHighlighted() && !this.infoPanel.activeSelf)
        {
            this.infoPanel.SetActive(true);
            return;
        }
        if (!base.IsHighlighted())
        {
            this.infoPanel.SetActive(false);
        }
    }
}