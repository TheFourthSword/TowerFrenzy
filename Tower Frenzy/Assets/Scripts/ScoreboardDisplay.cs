using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreboardDisplay : MonoBehaviour
{
    public Text scoreboardText;

    void Start()
    {
        List<ScoreEntry> scores = ScoreboardManager.Instance.GetScores();
        scoreboardText.text = "Top Scores:\n";

        foreach (ScoreEntry entry in scores)
        {
            scoreboardText.text += $"{entry.playerName}: {entry.score}\n";
        }
    }
}



