using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveLevel(Victory victory)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "level.fun";
        Debug.Log(path);
        FileStream stream = new FileStream(path, FileMode.Create);
        LevelData data = new LevelData(victory);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static LevelData LoadLevel()
    {
        string path = Application.persistentDataPath + "level.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            LevelData data = formatter.Deserialize(stream) as LevelData;
            Debug.Log(data.stars);
            Debug.Log(data.currentLevel);
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("save file not fount " + path);
            return null;
        }
    }
}
