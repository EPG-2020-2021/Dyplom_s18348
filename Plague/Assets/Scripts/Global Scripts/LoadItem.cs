using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LoadItem : MonoBehaviour
{

    Item item;
    SpriteRenderer sr;

    void Start()
    {
        item = GetComponent<Item>();
        sr = transform.GetComponent<SpriteRenderer>();
        Load();
    }

    public void Load()
    {
        //string itemName = name.GetComponent<Text>().text;

        if (File.Exists(Application.persistentDataPath
    + "/Items/" + item.ItemName + ".dat"))
        {
            ItemSave savedItem = new ItemSave();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/Items/" + item.ItemName + ".dat", FileMode.Open);
            savedItem = (ItemSave)bf.Deserialize(file);
            file.Close();
            item.ItemName = savedItem.ItemName;
            item.craftability = savedItem.craftability;
            //item.itemQuality = savedItem.itemQuality;
            item.SetGoodFeatures(savedItem.good);
            item.SetBadFeatures(savedItem.bad);
            if(Resources.Load<Sprite>("ItemPictures/" + item.ItemName) != null)
            {
                sr.sprite = Resources.Load<Sprite>("ItemPictures/" + item.ItemName);
            }
            else
            {
                Debug.LogError("Image not found");
                sr.sprite = Resources.Load<Sprite>("ItemPictures/Test" );
            }
            
            
        }
        else
            Debug.LogError("There is no save data for \"" + item.ItemName + "\" item!");
    }
}
