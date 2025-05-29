using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreboardDisplay : MonoBehaviour
{
    public Text scoreboardText;

    void Start()
    {
        List<int> scores = ScoreboardManager.Instance.GetScores();
        scoreboardText.text = "Top Scores:\n";

        foreach (int score in scores)
        {
            scoreboardText.text += score.ToString() + "\n";
        }
    }
}


