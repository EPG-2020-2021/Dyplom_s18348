using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class ApplyButton : MonoBehaviour
{
        
    public GameObject name;
    public GameObject goodFeature;
    public GameObject badFeature;

    CraftItem item = new CraftItem();

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SaveButton()
    {
        item = new CraftItem();
        LoadItem();
        item.ItemName = name.GetComponent<InputField>().text;
        item.craftability = true;
        if (goodFeature.GetComponent<InputField>().text!="")
        {
            item.AddGoodFeature(goodFeature.GetComponent<InputField>().text);
        } 
        if (badFeature.GetComponent<InputField>().text!="")
        {
            item.AddBadFeature(badFeature.GetComponent<InputField>().text);
        }
        SaveItem(name.GetComponent<InputField>().text);
    }

    
    public void LoadItem()
    {
        string itemName = name.GetComponent<InputField>().text;

        if (File.Exists(Application.persistentDataPath
    + "/Items/" + itemName + ".dat"))
        {
            ItemSave savedItem = new ItemSave();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/Items/"+ itemName + ".dat", FileMode.Open);
            savedItem = (ItemSave)bf.Deserialize(file);
            file.Close();
            item.ItemName = savedItem.ItemName;
            item.craftability = savedItem.craftability;
            item.itemQuality = savedItem.itemQuality;
            item.SetGoodFeatures(savedItem.good);
            item.SetBadFeatures(savedItem.bad);
            Debug.Log(item.ItemName + "'s game data loaded! =====================================");
            Show(item.GetGoodFeatures());
            Show(item.GetBadFeatures());
        }
        else
            Debug.Log("There is no save data for " + itemName + "!");
    }

    void Show(List<string> list)
    {
        foreach (string item in list)
        {
            Debug.Log(item);
        }
    }
    void SaveItem(string itemName)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/Items/" + itemName + ".dat");
        ItemSave savedItem = new ItemSave(item);
        bf.Serialize(file, savedItem);
        file.Close();
        Debug.Log("Game data saved!");
    }
}
