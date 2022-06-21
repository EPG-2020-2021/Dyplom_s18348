using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class SaveSystem
{
    private static string savePath = "/Saves";
    private static string statsPath = "/Stats/";
    private static string containersPath = "/Containers/";
    private static string fileType = ".rims";

    private static bool loaded = false;

    #region Stats
    public static void SaveStats(CharacterStats character)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + savePath + statsPath;
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        path += character.gameObject.name + fileType;
        FileStream stream = new FileStream(path, FileMode.Create);

        var stats = character.GetStats();
        StatsData data = new StatsData(stats);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void LoadStats(CharacterStats character)
    {
        string path = Application.persistentDataPath + savePath + statsPath + character.gameObject.name + fileType;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            StatsData data = formatter.Deserialize(stream) as StatsData;

            stream.Close();

            StatsApplier.ApplyStats(data.GetStats(), character.gameObject, true);

            GameObject.Destroy(data.GetStats());
            Debug.Log("load stats for " + character.gameObject.name);
        }
        else
        {
            Debug.LogError("Save file not found " + character.gameObject.name);
        }

    }

    #endregion

    #region Container   

    public static void SaveContainer(ItemContainer itemContainer)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + savePath + containersPath;
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        path += itemContainer.gameObject.name + fileType;
        FileStream stream = new FileStream(path, FileMode.Create);

        ContainerData data = new ContainerData(itemContainer);

        formatter.Serialize(stream, data);
        stream.Close();
    }


    private static void LoadContainer(ItemContainer itemContainer)
    {
        string path = Application.persistentDataPath + savePath + containersPath + itemContainer.gameObject.name + fileType;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ContainerData data = formatter.Deserialize(stream) as ContainerData;

            stream.Close();

            itemContainer.containerFiller.Load(data.GetObjects());
        }
        else
        {
            Debug.LogError("Save file not found");
        }
    }
    #endregion

    public static void MasterLoad()
    {

        LoadContainer(PlayerScript.instance.inventory);
        LoadStats(PlayerScript.instance.playerStats);

        loaded = true;
    }
}
