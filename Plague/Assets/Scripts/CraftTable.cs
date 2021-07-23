using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CraftTable : MonoBehaviour
{

    public CraftItem firstItem;
    public CraftItem secondItem;
    public CraftItem thirdItem;

    CraftItem[] items;


    int[] randArr;

    public CraftItem resultItem;

    System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {   resultItem = (CraftItem) GameObject.Instantiate(Resources.Load<CraftItem>("Prefabs/Craft Item"));
        resultItem.gameObject.GetComponent<LoadItem>().enabled = false;
        //resultItem = new Item();
        randArr = new int[3];
        StartCoroutine(Craft());
    }

    bool isLoaded()
    {
        foreach (var ci in items)
        {
            if (!ci.gameObject.GetComponent<LoadItem>().loaded)
            {
                return false;
            }
        }
        return true;
    }

    public IEnumerator Craft()
    {
        
        float success;
        float fail;
        items = new CraftItem[] { firstItem, secondItem
         //   , thirdItem 
        
        };
        yield return new WaitUntil(() => isLoaded());
        for (int i = 0; i < items.Length; i++)
        {
            print(items[i].good.Count);
            success = 1f / 9f * items[i].itemQuality;
            Debug.Log("quality: " + items[i].itemQuality);
            Debug.Log("Success: " + success);
            fail = 100f - (1f / 5f * (101f - items[i].itemQuality));
            Debug.Log("Fail: " + fail);

            randArr[i] = random.Next(101);
            Debug.Log("Random: " + randArr[i]);
            if (randArr[i] < success) //first variant
            {
                Debug.Log("first variant");
                for (int j = 0; j < items[i].good.Count; j++)
                {
                    print(items[i].good[j]);
                    resultItem.AddGoodFeature(items[i].good[j]);
                }
            } else if (randArr[i] < items[i].itemQuality && randArr[i] > success) //second variant
            {
                Debug.Log("second variant");
                for (int j = 0; j < items[i].good.Count; j++)
                {
                    print(items[i].good[j]);
                    print(items[i].good.Count);
                    resultItem.AddGoodFeature(items[i].good[j]);
                }
                for (int j = 0; j < items[i].bad.Count; j++)
                {
                    resultItem.AddBadFeature(items[i].bad[j]);
                }
            }
            else if (randArr[i] > items[i].itemQuality && randArr[i] < fail) //third variant
            {
                Debug.Log("third variant");
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

                    print(items[i].good[goodfeatures[k]]);
                    resultItem.AddGoodFeature(items[i].good[goodfeatures[k]]);
                }

                for (int j = 0; j < items[i].bad.Count; j++)
                {
                    resultItem.AddBadFeature(items[i].bad[j]);
                }
            } else if (randArr[i] > fail) //fourth variant
            {
                Debug.Log("fourth variant");
                for (int j = 0; j < items[i].bad.Count; j++)
                {
                    resultItem.AddBadFeature(items[i].bad[j]);
                }
            }

        }


    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
