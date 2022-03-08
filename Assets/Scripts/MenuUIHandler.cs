using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField userNameText;
    public static MenuUIHandler Instance;
    public TextMeshProUGUI HighScoreText;

    /*
    private void Start()
    {
        PlayerData.Instance.bestScore = 0;
        PlayerData.Instance.userName = "There is no best score";
        PlayerData.Instance.SaveDataName();
        PlayerData.Instance.SaveDataBestScore();
    }
    */

    private void Awake()
    {
        Instance = this;
        DisplayBestScore();
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
        PlayerData.Instance.userName = userNameText.text;
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    void DisplayBestScore()
    {
        PlayerData.Instance.LoadDataBestScore();
        PlayerData.Instance.LoadDataName();

        if (PlayerData.Instance.bestScoreUserName == null)
        {
            PlayerData.Instance.bestScoreUserName = "There is no best score";
        }

        HighScoreText.text = "Best Score: " + PlayerData.Instance.bestScoreUserName + " " + PlayerData.Instance.bestScore;
    }
}
