using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class ScoreEntry
{
    public string playerName;
    public int score;
}

[System.Serializable]
public class ScoreboardData
{
    public List<ScoreEntry> scores = new List<ScoreEntry>();
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

    public void AddScore(string playerName, int score)
    {
        if (scoreboard == null)
        {
            scoreboard = new ScoreboardData(); // Prevent null reference
        }

        ScoreEntry newEntry = new ScoreEntry { playerName = playerName, score = score };
        scoreboard.scores.Add(newEntry);

        scoreboard.scores = scoreboard.scores
            .OrderByDescending(s => s.score)
            .Take(MaxEntries)
            .ToList();

        SaveScoreboard();
    }


    public List<ScoreEntry> GetScores()
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





