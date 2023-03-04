using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SOG.Managers.SaveManager
{
  public static class SaveSystem
  {
    public static void SaveData(Data data)
    {
      BinaryFormatter formatter = new BinaryFormatter();
      string path = Application.persistentDataPath + "/HungrySave.fish";
      FileStream stream = new FileStream(path, FileMode.Create);

      Data newData = new Data(data.bestScore, data.masterMusicVolume, data.isFirstTime);

      formatter.Serialize(stream, newData);
      stream.Close();
    }

    public static Data LoadData()
    {
      string path = Application.persistentDataPath + "/HungrySave.fish";

      if (File.Exists(path))
      {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        Data oldData = formatter.Deserialize(stream) as Data;
        stream.Close();
        return oldData;
      }
      else
      {
        Debug.LogError("Save file cant find in this path: " + path);
        return null;
      }
    }
  }
}

