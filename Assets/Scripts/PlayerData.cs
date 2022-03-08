using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;
    public string BestScoreTextString;
    public MenuUIHandler menuUIHandlerScript;
    public string userName;
    public int bestScore;
    public string bestScoreUserName;

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
        public string userNameSaved;
        public int userHighScoreSaved;
    }

    public void SaveDataName()
    {
        SaveData dataName = new SaveData();
        dataName.userNameSaved = userName;

        string json = JsonUtility.ToJson(dataName);

        File.WriteAllText(Application.persistentDataPath + "/savedUserName.json", json);
    }

    public void SaveDataBestScore()
    {
        SaveData dataBestScore = new SaveData();
        dataBestScore.userHighScoreSaved = bestScore;

        string json = JsonUtility.ToJson(dataBestScore);

        File.WriteAllText(Application.persistentDataPath + "/savedUserBestScore.json", json);
    }

    public void LoadDataBestScore()
    {
        string path = Application.persistentDataPath + "/savedUserBestScore.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData dataBestScore = JsonUtility.FromJson<SaveData>(json);

            bestScore = dataBestScore.userHighScoreSaved;
        }
        else return;
    }

    public void LoadDataName()
    {
        string path = Application.persistentDataPath + "/savedUserName.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData dataName = JsonUtility.FromJson<SaveData>(json);

            bestScoreUserName = dataName.userNameSaved;
        }
    }
}
