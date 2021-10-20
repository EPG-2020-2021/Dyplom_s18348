using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

	#region Singleton

	public static Inventory instance;

	public GameObject craftTable;

	void Awake()
	{
        if (instance == null)
        {
			print("new instance");
   instance = this;
        }
     
	}

    #endregion

    private void Start()
    {
			
    }

    public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public int space = 1;

	
	public List<Item> items = new List<Item>();

	
	public void Add(Item item)
	{
		//if (item.showInInventory)
		if (true)
		{
			if (items.Count >= space)
			{
				Debug.Log("Not enough room.");
				return;
			}

			items.Add(item);
		

			if (onItemChangedCallback != null)
				onItemChangedCallback.Invoke();
		}
	}

	// Remove an item
	public void Remove(Item item)
	{
		print(items.Count);
		items.Remove(item);

		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}

}