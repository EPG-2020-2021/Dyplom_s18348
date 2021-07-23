using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    GameObject player;
    Stats playerStats;
    public List<Creature> creatures;
    public List<Quest> quests;

    public List<Quest> complitedQuests;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<Stats>();
    }

    public bool checkItemQuality(CraftItem item, float quality)
    {
        if (quality == 0f)
        {
            return true;
        }

        else if (item.itemQuality < quality)
        {
            return false;
        }
        return true;
    }
    public bool checkItemName(CraftItem item, string name)
    {
        if (name.Equals("null"))
        {
            return true;
        }
        else if (!item.ItemName.Equals(name))
        {
            return false;
        }
        return true;
    }
    public bool checkItemFeatures(CraftItem item, List<string> features)
    {
        if (features == null)
        {
            return true;
        }
        else
        {

            foreach (var feature in item.good)
            {
                if (!features.Contains(feature))
                {
                    return false;
                }
            }
        }
        
        return true;
    }

    public void giveReward(float exp, GameObject reward)
    {
        playerStats.addExp(exp);
        if (reward != null) { 
        Instantiate(reward, player.transform.position, player.transform.rotation);
    }
    }

    public void EndQuest(Quest quest)
    {
        complitedQuests.Add(quest);
    }
}
