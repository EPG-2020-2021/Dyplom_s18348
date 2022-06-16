using System.Collections;
using System.Collections.Generic;
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



    private bool _inited = false;

    private void Start()
    {
        Init();
    }

    public void Remove()
    {
        containerController.Remove(this.item);
        /*Destroy(item.gameObject);*/item?.gameObject.SetActive(false);
        item = null;
        _inited = false;
        UpdateSlot();
    }

    public void Use()
    {
        if (item && item.GetComponent<IUsable>() != null)
        {
            item.GetComponent<IUsable>().Use();
            Remove();
        }
    }

    public void Init()
    {
        if (!_inited)
        {
            //containerController = UIManager.instance.inventoryController;

            containerController.onContainerUpdateCallback += UpdateSlot;

            if(_sellButton)UIManager.instance.shopUi.onShopUpdateCallback += SellButtonUpdate;
            
            if(_giveButton) PlayerScript.instance.givable.onGivableSetCallback += GiveButtonUpdate;

            _infoPanel = GetComponentInChildren<InfoPanel>();

            _inited = true;
        }   
        
    }

    public void UpdateSlot()
    {
        _icon.enabled = !(item is null);
        if (_deleteButton != null)
        {
             _deleteButton.interactable = !(item is null);
        }
        _icon.sprite = item is null? null : item.icon;

        if (item) _infoPanel.Fill(item);

        SellButtonUpdate();
    }

    //additional for shop


    public void Buy()
    {
        if (item)
        {
            if (UIManager.instance.shopUi.TryToBuy(item))
            {
                Remove();
            }           
        }
    }
    public void Sell()
    {
        if (item)
        {
            UIManager.instance.shopUi.Sell(item);
            Remove();
        }
    }


    public void SellButtonUpdate()
    {
        if (_sellButton is null) return;

            if (UIManager.instance.shopUi.container)
        {
            _sellButton.interactable = !(item is null);
            return;
        }
        _sellButton.interactable = false;
    }

    // Additional for healing

    public void Give()
    {
        PlayerScript.instance.givable.closest.PutObject(item);
        Remove();
    }

    public void GiveButtonUpdate()
    {
        if (_giveButton is null) return;

        if (!(PlayerScript.instance.givable.closest is null))
        {
            _giveButton.interactable = !(item is null);
            return;
        }
        _giveButton.interactable = false;
    }

    public void Take()
    {
        if (item)
        {
            PlayerScript.instance.inventory.Add(item);
            Remove();
        }
    }

    public void Craft()
    {
        if (item)
        {
            Take();
        }
        else
        {
            CraftUIController controller = (CraftUIController)containerController;
            controller.Craft();
        }
    }
}
