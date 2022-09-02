using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    //public static void SaveData(Player player)
    //{
    //    BinaryFormatter formatter = new BinaryFormatter();
    //    string path = Application.persistentDataPath + "/save.npgame";
    //    FileStream stream = new FileStream(path, FileMode.Create);

    //    PlayerData data = new PlayerData(player);

    //    formatter.Serialize(stream, data);
    //    stream.Close();
    //}

    //public static PlayerData LoadData()
    //{
    //    string path = Application.persistentDataPath + "/save.npgame";
    //    if (File.Exists(path))
    //    {
    //        BinaryFormatter binaryreader = new BinaryFormatter();
    //        FileStream stream = new FileStream(path, FileMode.Open);

    //        PlayerData data = binaryreader.Deserialize(stream) as PlayerData;
    //        stream.Close();
    //        return data;
    //    }
    //    else
    //    {
    //        Debug.LogError("No save file in" + path);
    //        return null;
    //    }
    //}

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

        using (StreamReader reader = new StreamReader(path))
        {
            string json = reader.ReadToEnd();
            PlayerData returnData = JsonUtility.FromJson<PlayerData>(json);
            return returnData;
        }
    }
}
