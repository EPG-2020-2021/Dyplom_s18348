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

    private UIInventoryController inventoryController;


    private void Start()
    {
        Init();
    }

    public void Remove()
    {
        inventoryController.Remove(this.item);
        Destroy(item.gameObject);
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
        if (!inventoryController)
        {
            inventoryController = UIManager.instance.inventoryController;
            inventoryController.onInventoryUpdateCallback += UpdateSlot;
            _infoPanel = GetComponentInChildren<InfoPanel>();
        }   
        
    }

    public void UpdateSlot()
    {
        _icon.enabled = !(item is null);
        _closeButton.interactable = !(item is null);
        _icon.sprite = item is null? null : item.icon;

        if (item) _infoPanel.Fill(item);
    } 



}
