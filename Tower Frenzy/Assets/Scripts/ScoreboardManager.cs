using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class ScoreboardData
{
    public List<int> scores = new List<int>();
}

public class ScoreboardManager : MonoBehaviour
{
    public static ScoreboardManager Instance;

    private ScoreboardData scoreboard;
    private const string ScoreboardKey = "Scoreboard";
    public int MaxEntries = 5;

    private void Awake()
    {
        Debug.Log("ScoreboardManager ready");
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadScoreboard();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int score)
    {
        scoreboard.scores.Add(score);

        // Keep only top scores
        scoreboard.scores = scoreboard.scores
            .OrderByDescending(s => s)
            .Take(MaxEntries)
            .ToList();

        SaveScoreboard();
    }

    public List<int> GetScores()
    {
        return scoreboard.scores;
    }

    private void SaveScoreboard()
    {
        string json = JsonUtility.ToJson(scoreboard);
        PlayerPrefs.SetString(ScoreboardKey, json);
        PlayerPrefs.Save();
    }

    private void LoadScoreboard()
    {
        string json = PlayerPrefs.GetString(ScoreboardKey, "");
        if (!string.IsNullOrEmpty(json))
        {
            scoreboard = JsonUtility.FromJson<ScoreboardData>(json);
        }
        else
        {
            scoreboard = new ScoreboardData();
        }
    }

    public void ClearScoreboard()
    {
        PlayerPrefs.DeleteKey(ScoreboardKey);
        scoreboard = new ScoreboardData();
    }
}


