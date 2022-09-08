using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void SaveData(Player player)
    {
        string path = Application.persistentDataPath + "/save.NPgame";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream datastream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player);

        formatter.Serialize(datastream, data);
        datastream.Close();
    }
    public static PlayerData LoadData()
    {
        string path = Application.persistentDataPath + "/save.NPgame";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream datastream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(datastream) as PlayerData;
            datastream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
}
