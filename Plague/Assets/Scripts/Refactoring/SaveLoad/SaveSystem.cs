using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class SaveSystem
{
    private static string savePath = "/Saves";
    private static string statsPath = "/Stats/";
    private static string fileType = ".rims";
    public static void SaveStats(CharacterStats character)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + savePath + statsPath + character.gameObject.name + fileType;
        FileStream stream = new FileStream(path, FileMode.Create);

        var stats = character.GetStats();
        StatsData data = new StatsData(stats);

        formatter.Serialize(stream, data);
        stream.Close();

        Debug.Log($"Successful save {path}");
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
        }
        else
        {
            Debug.LogError("Save file not found");
        }

    }
}
