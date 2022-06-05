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
    private Button _closeButton;
    [SerializeField]
    private Button _itemButton;
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
            _infoPanel = GetComponentInChildren<InfoPanel>();

            _inited = true;
        }   
        
    }

    public void UpdateSlot()
    {
        _icon.enabled = !(item is null);
        if (_closeButton != null)
        {
             _closeButton.interactable = !(item is null);
        }
        _icon.sprite = item is null? null : item.icon;

        if (item) _infoPanel.Fill(item);
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
}
