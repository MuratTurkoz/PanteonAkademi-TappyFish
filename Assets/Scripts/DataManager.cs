using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string namePlayer;

  
    public int scorePlayer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {      
        public int Score;     
    }

    public void SaveScore()
    {
        SaveData data = new SaveData {  Score = scorePlayer};
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json",
            json);
    }

    public void SaveScore( int _score)
    {
        SaveData data = new SaveData {  Score = _score };
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json",
            json);
    }

    public int LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            //namePlayer = data.Name.ToString();
            return data.Score;
        }
        return 0;
    }


}
