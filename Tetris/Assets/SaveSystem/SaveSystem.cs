using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SocialPlatforms.Impl;

public static class SaveSystem
{

    public static void SaveData(Player player)
    {
        string path = Application.persistentDataPath + "/save.json";
        string json = JsonUtility.ToJson(player);
        using (StreamWriter writer = new StreamWriter(path))
        {
            writer.Write(json);
        }
    }
    public static PlayerData LoadData()
    {
        string path = Application.persistentDataPath + "/save.json";
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                PlayerData returnData = JsonUtility.FromJson<PlayerData>(json);
                return returnData;
            }
        }
        else
        {
            return null;
        }

    }

}
