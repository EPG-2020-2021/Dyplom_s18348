using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    SystemLanguage language = SystemLanguage.English;
    bool isLoaded = false;

    static string path = "";

    void Start()
    {
        if (!isLoaded) 
        {
            language = Application.systemLanguage;
            Debug.Log(language.ToString());
        }

        path = Application.dataPath + "/Languages/" + language.ToString() + "/";
    }

    public static void QuestTranslation(Quest obj)
    {
        string savedData = File.ReadAllText(path + obj.key + ".txt");
        QuestSave loaded = JsonUtility.FromJson<QuestSave>(savedData);

        obj.name = loaded.name;
        obj.questDescription = loaded.questDescription;
    }
}
