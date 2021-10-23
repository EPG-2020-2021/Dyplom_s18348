using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CraftTable : MonoBehaviour
{
    public static CraftTable instance;
    int maxSlots = 3;

    public List<CraftItem> items;


    int[] randArr;

    public CraftItem resultItem;

    System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start(){
        items = new List<CraftItem>();
        //resultItem = new Item();
        randArr = new int[3];
        //StartCoroutine(Craft());
    }

    public bool Add(Item item)
    {
        print("ADD_incrafttable");
            if (item.craftability && items.Count<maxSlots)
            {
                items.Add((CraftItem)item);
                if (onItemAddCallback != null)
                    onItemAddCallback.Invoke();
                
            
            
            return true;
            }
        return false;
        
    }

    public void Remove()
    {
        items = new List<CraftItem>();
        if (onItemRemoveCallback != null)
            onItemRemoveCallback.Invoke();
    }

    public void Remove(CraftItem item)
    {
        items.Remove(item);
        //if (onItemRemoveCallback != null)
        //    onItemRemoveCallback.Invoke();
    }

    bool isLoaded()
    {//ci - craft item
        foreach (var ci in items)
        {
            if (!ci.gameObject.GetComponent<LoadItem>().loaded)
            {
                return false;
            }
        }
        return true;
    }

    public delegate void OnItemAdd();
    public OnItemAdd onItemAddCallback;
    public delegate void OnItemRemove();
    public OnItemRemove onItemRemoveCallback;
    public delegate void OnItemResult();
    public OnItemRemove onItemResultCallback;

    public void Craft()
    {
        if (items.Count > 1 && items.Count < 4)
        {


            resultItem = (CraftItem)GameObject.Instantiate(Resources.Load<CraftItem>("Prefabs/Craft Item"));
            resultItem.gameObject.GetComponent<LoadItem>().enabled = false;
            resultItem.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("ItemPictures/potion");
            resultItem.icon = resultItem.GetComponent<SpriteRenderer>();
            resultItem.gameObject.SetActive(false);
            float success;
            float fail;
            //items = new CraftItem[2];// { firstItem, secondItem
            //   , thirdItem 

            // };
            // yield return new WaitUntil(() => isLoaded());

            for (int i = 0; i < items.Count; i++)
            {

                success = 1f / 9f * items[i].itemQuality;

                fail = 100f - (1f / 5f * (101f - items[i].itemQuality));


                randArr[i] = random.Next(101);

                if (randArr[i] < success) //first variant
                {

                    for (int j = 0; j < items[i].good.Count; j++)
                    {

                        resultItem.AddGoodFeature(items[i].good[j]);
                    }
                }
                else if (randArr[i] < items[i].itemQuality && randArr[i] > success) //second variant
                {

                    for (int j = 0; j < items[i].good.Count; j++)
                    {

                        resultItem.AddGoodFeature(items[i].good[j]);
                    }
                    for (int j = 0; j < items[i].bad.Count; j++)
                    {
                        resultItem.AddBadFeature(items[i].bad[j]);
                    }
                }
                else if (randArr[i] > items[i].itemQuality && randArr[i] < fail) //third variant
                {

                    // int[] goodfeatures = new int[items[i].good.Count * randArr[i]];

                    List<int> goodfeatures = new List<int>();
                    int localrand = 0;
                    for (int k = 0; k < items[i].good.Count * randArr[i] / 100; k++)
                    {
                        while (true)
                        {
                            localrand = random.Next(items[i].good.Count);
                            if (!goodfeatures.Contains(localrand))
                            {
                                goodfeatures.Add(localrand);
                                break;
                            }
                        }


                        resultItem.AddGoodFeature(items[i].good[goodfeatures[k]]);
                    }

                    for (int j = 0; j < items[i].bad.Count; j++)
                    {
                        resultItem.AddBadFeature(items[i].bad[j]);
                    }
                }
                else if (randArr[i] > fail) //fourth variant
                {

                    for (int j = 0; j < items[i].bad.Count; j++)
                    {
                        resultItem.AddBadFeature(items[i].bad[j]);
                    }
                }

            }
            if (onItemResultCallback != null)
                onItemResultCallback.Invoke();
            instance.Remove();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
