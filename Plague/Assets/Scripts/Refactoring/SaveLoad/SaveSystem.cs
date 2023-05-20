using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    private static string savePath;

    private static string statsPath;

    private static string containersPath;

    private static string moneyPath;

    private static string questsPath;

    private static string fileType;

    private static bool loaded;

    static SaveSystem()
    {
        SaveSystem.savePath = "/Saves";
        SaveSystem.statsPath = "/Stats/";
        SaveSystem.containersPath = "/Containers/";
        SaveSystem.moneyPath = "/Money/";
        SaveSystem.questsPath = "/Quests/";
        SaveSystem.fileType = ".rims";
        SaveSystem.loaded = false;
    }

    public static void DeleteSaves()
    {
        Directory.Delete(String.Concat(Application.persistentDataPath, SaveSystem.savePath), true);
    }

    private static void LoadContainer(ItemContainer itemContainer)
    {
        string str = String.Concat(new String[] { Application.persistentDataPath, SaveSystem.savePath, SaveSystem.containersPath, itemContainer.gameObject.name, SaveSystem.fileType });
        if (!File.Exists(str))
        {
            Debug.LogError("Save file not found");
            return;
        }
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(str, FileMode.Open);
        ContainerData containerDatum = binaryFormatter.Deserialize(fileStream) as ContainerData;
        fileStream.Close();
        itemContainer.containerFiller.Load(containerDatum.GetObjects());
    }

    private static void LoadMoney()
    {
        string str = String.Concat(new String[] { Application.persistentDataPath, SaveSystem.savePath, SaveSystem.moneyPath, "PlayersMoney", SaveSystem.fileType });
        if (!File.Exists(str))
        {
            Debug.LogError("Save file not found");
            return;
        }
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(str, FileMode.Open);
        MoneyData moneyDatum = binaryFormatter.Deserialize(fileStream) as MoneyData;
        fileStream.Close();
        PlayerScript.instance.moneyController.Set(moneyDatum.GetMoney());
    }
    public static bool LoadQuest(string name)
    {
        string str = String.Concat(new String[] { Application.persistentDataPath, SaveSystem.savePath, SaveSystem.questsPath, name, SaveSystem.fileType });
        if (!File.Exists(str))
        {
            Debug.LogError("Save file not found");
            return false;
        }
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(str, FileMode.Open);
        QuestData questDatum = binaryFormatter.Deserialize(fileStream) as QuestData;
        fileStream.Close();

        return questDatum.IsComplete();
    }

    public static void LoadStats(CharacterStats character)
    {
        string str = String.Concat(new String[] { Application.persistentDataPath, SaveSystem.savePath, SaveSystem.statsPath, character.gameObject.name, SaveSystem.fileType });
        if (!File.Exists(str))
        {
            Debug.LogError(String.Concat("Save file not found ", character.gameObject.name));
            return;
        }
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(str, FileMode.Open);
        StatsData statsDatum = binaryFormatter.Deserialize(fileStream) as StatsData;
        fileStream.Close();
        StatsApplier.ApplyStats(statsDatum.GetStats(), character.gameObject, true);
        Object.Destroy(statsDatum.GetStats());
        Debug.Log(String.Concat("load stats for ", character.gameObject.name));
    }

    public static void MasterLoad()
    {
        SaveSystem.LoadContainer(PlayerScript.instance.inventory);
        SaveSystem.LoadStats(PlayerScript.instance.playerStats);
        SaveSystem.LoadMoney();
        SaveSystem.loaded = true;
    }

    public static void SaveContainer(ItemContainer itemContainer)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string str = String.Concat(Application.persistentDataPath, SaveSystem.savePath, SaveSystem.containersPath);
        if (!Directory.Exists(str))
        {
            Directory.CreateDirectory(str);
        }
        if (File.Exists(str))
        {
            File.Delete(str);
        }
        str = String.Concat(str, itemContainer.gameObject.name, SaveSystem.fileType);
        FileStream fileStream = new FileStream(str, FileMode.Create);
        binaryFormatter.Serialize(fileStream, new ContainerData(itemContainer));
        fileStream.Close();
    }

    public static void SaveMoney()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string str = String.Concat(Application.persistentDataPath, SaveSystem.savePath, SaveSystem.moneyPath);
        if (!Directory.Exists(str))
        {
            Directory.CreateDirectory(str);
        }
        if (File.Exists(str))
        {
            File.Delete(str);
        }
        str = String.Concat(str, "PlayersMoney", SaveSystem.fileType);
        FileStream fileStream = new FileStream(str, FileMode.Create);
        MoneyData moneyDatum = new MoneyData(PlayerScript.instance.moneyController.GetMoneyAmount());
        binaryFormatter.Serialize(fileStream, moneyDatum);
        fileStream.Close();
    }
    public static void SaveQuest(string name, bool complete)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string str = String.Concat(Application.persistentDataPath, SaveSystem.savePath, SaveSystem.questsPath);
        if (!Directory.Exists(str))
        {
            Directory.CreateDirectory(str);
        }
        if (File.Exists(str))
        {
            File.Delete(str);
        }
        str = String.Concat(str, name, SaveSystem.fileType);
        FileStream fileStream = new FileStream(str, FileMode.Create);
        QuestData questDatum = new QuestData(name, complete);
        binaryFormatter.Serialize(fileStream, questDatum);
        fileStream.Close();
    }

    public static void SaveStats(CharacterStats character)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string str = String.Concat(Application.persistentDataPath, SaveSystem.savePath, SaveSystem.statsPath);
        if (!Directory.Exists(str))
        {
            Directory.CreateDirectory(str);
        }
        str = String.Concat(str, character.gameObject.name, SaveSystem.fileType);
        FileStream fileStream = new FileStream(str, FileMode.Create);
        binaryFormatter.Serialize(fileStream, new StatsData(character.GetStats()));
        fileStream.Close();
        Debug.Log("Saved stats");
    }
}