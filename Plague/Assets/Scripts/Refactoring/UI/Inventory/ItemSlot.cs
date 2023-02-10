using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField]
    private Image _icon;

    public Object item;

    [SerializeField]
    private Button _deleteButton;

    [SerializeField]
    private Button _sellButton;

    [SerializeField]
    private Button _itemButton;

    [SerializeField]
    private Button _giveButton;

    [SerializeField]
    private InfoPanel _infoPanel;

    public UIContainerController containerController;

    private bool _inited;

    public ItemSlot()
    {
    }

    public void Buy()
    {
        if (this.item && UIManager.instance.shopUi.TryToBuy(this.item))
        {
            this.Remove();
        }
    }

    public void Craft()
    {
        if (this.item)
        {
            this.Take();
            return;
        }
        ((CraftUIController)this.containerController).Craft();
    }

    public void Give()
    {
        PlayerScript.instance.givable.closest.PutObject(this.item);
        this.Remove();
    }

    public void GiveButtonUpdate()
    {
        if (this._giveButton == null)
        {
            return;
        }
        if (PlayerScript.instance.givable.closest == null)
        {
            this._giveButton.interactable = false;
            return;
        }
        if (this.item && PlayerScript.instance.givable.obj && this.item.name.Equals("Streptomycin") && PlayerScript.instance.givable.obj.CompareTag("Npc"))
        {
            this._giveButton.interactable = false;
            return;
        }
        this._giveButton.interactable = this.item != null;
    }

    public void Init()
    {
        if (!this._inited)
        {
            this.containerController.onContainerUpdateCallback += new UIContainerController.OnContainerUpdate(this.UpdateSlot);
            if (this._sellButton)
            {
                UIManager.instance.shopUi.onShopUpdateCallback += new UIContainerController.OnContainerUpdate(this.SellButtonUpdate);
            }
            if (this._giveButton)
            {
                PlayerScript.instance.givable.onGivableSetCallback += new Givable.OnGivableSet(this.GiveButtonUpdate);
            }
            this._infoPanel = base.GetComponentInChildren<InfoPanel>();
            this._inited = true;
        }
    }

    public void Remove()
    {
        this.containerController.Remove(this.item);
        Object obj = this.item;
        if (obj != null)
        {
            obj.gameObject.SetActive(false);
        }
        else
        {
        }
        this.item = null;
        this._inited = false;
        this.UpdateSlot();
    }

    public void Sell()
    {
        if (this.item)
        {
            UIManager.instance.shopUi.Sell(this.item);
            this.Remove();
        }
    }

    public void SellButtonUpdate()
    {
        if (this._sellButton == null)
        {
            return;
        }
        if (!UIManager.instance.shopUi.container)
        {
            this._sellButton.interactable = false;
            return;
        }
        this._sellButton.interactable = this.item != null;
    }

    private void Start()
    {
        this.Init();
    }

    public void Take()
    {
        if (this.item)
        {
            PlayerScript.instance.inventory.Add(this.item, null);
            this.Remove();
        }
    }

    public void UpdateSlot()
    {
        Sprite sprite;
        this._icon.enabled = this.item != null;
        if (this._deleteButton != null)
        {
            this._deleteButton.interactable = this.item != null;
        }
        Image image = this._icon;
        if (this.item == null)
        {
            sprite = null;
        }
        else
        {
            sprite = this.item.icon;
        }
        image.sprite = sprite;
        if (this.item)
        {
            this._infoPanel.Fill(this.item);
        }
        this.SellButtonUpdate();
        this.GiveButtonUpdate();
    }

    public void Use()
    {
        if (this.item && this.item.GetComponent<IUsable>() != null)
        {
            this.item.GetComponent<IUsable>().Use();
            this.Remove();
        }
    }
}