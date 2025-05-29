using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;

[System.Serializable]
public class ScoreEntry
{
    public string playerName;
    public int score;
}

[System.Serializable]
public class Scoreboard
{
    public List<ScoreEntry> scores = new List<ScoreEntry>();
}

public class PointCounter : MonoBehaviour
{
    private void AddToScoreboard(string name, int score)
    {
        ScoreEntry newEntry = new ScoreEntry { playerName = name, score = score };
        scoreboard.scores.Add(newEntry);

        // Sort by score descending and keep top 5
        scoreboard.scores = scoreboard.scores.OrderByDescending(s => s.score).Take(5).ToList();
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
            scoreboard = JsonUtility.FromJson<Scoreboard>(json);
        }
        else
        {
            scoreboard = new Scoreboard(); // Empty
        }
    }

    private void UpdateScoreboardText()
    {
        if (scoreboardText == null) return;

        scoreboardText.text = "Top Scores:\n";
        foreach (var entry in scoreboard.scores)
        {
            scoreboardText.text += $"{entry.playerName}: {entry.score}\n";
        }
    }


    [SerializeField] private string playerName = "Player1"; // You could prompt this via UI
    [SerializeField] private Text scoreboardText; // Assign in Inspector
    private Scoreboard scoreboard;
    private const string ScoreboardKey = "Scoreboard";


    public int points;
    [SerializeField] public List<string> PossibleBoxes = new List<string>() { "BoxBrown", "BoxPink", "BoxGreen", "BoxRed" };
    [SerializeField] public List<string> CorrectBoxes = new List<string>() { };
    public List<GameObject> BoxesObject = new List<GameObject>();
    public List<string> CurrentBoxes = new List<string>();
    [SerializeField] private Text feedbackText;
    [SerializeField] private Text HighScoreText;
    private int HighScore;

    // Start is called before the first frame update
    void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreText();
        LoadScoreboard();
        UpdateScoreboardText();
        GenerateNewCorrectBoxes();
    }


    private void GenerateNewCorrectBoxes()
    {
        // Clear the current CorrectBoxes list and generate a new set of random boxes
        CorrectBoxes.Clear();

        // Select a random number of boxes (you can adjust how many boxes you want)
        int numBoxes = Random.Range(2, PossibleBoxes.Count + 1); // Random number of boxes to select (2 to 4)

        // Add random boxes to CorrectBoxes
        for (int i = 0; i < numBoxes; i++)
        {
            string box = PossibleBoxes[Random.Range(0, PossibleBoxes.Count)];
            CorrectBoxes.Add(box);
        }

        // Optionally, shuffle CorrectBoxes if you want them to appear in a random order
        ShuffleList(CorrectBoxes);
        UpdateFeedbackText();
    }

    private void ShuffleList(List<string> list)
    {
        // Fisher-Yates shuffle to randomize the list order
        for (int i = 0; i < list.Count; i++)
        {
            string temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    private void UpdateFeedbackText()
    {
        // Display the current CorrectBoxes in the feedbackText UI element
        feedbackText.text = "Stack these boxes: \n";
        foreach (string box in CorrectBoxes)
        {
            feedbackText.text += box + "\n";
        }
    }

    private void UpdateHighScoreText()
    {
        // Update the high score UI text
        HighScoreText.text = "High Score: " + HighScore.ToString();
    }

    private void Update()
    {
        //loadbearing update function
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BoxBrown"))
        {
            BoxesObject.Add(collision.gameObject);
            CurrentBoxes.Add("BoxBrown");
        }

        if (collision.gameObject.CompareTag("BoxPink"))
        {
            BoxesObject.Add(collision.gameObject);
            CurrentBoxes.Add("BoxPink");
        }

        if (collision.gameObject.CompareTag("BoxGreen"))
        {
            BoxesObject.Add(collision.gameObject);
            CurrentBoxes.Add("BoxGreen");
        }

        if (collision.gameObject.CompareTag("BoxRed"))
        {
            BoxesObject.Add(collision.gameObject);
            CurrentBoxes.Add("BoxRed");
        }

        if (CurrentBoxes.Count == CorrectBoxes.Count &&
    !CurrentBoxes.Except(CorrectBoxes).Any() &&
    !CorrectBoxes.Except(CurrentBoxes).Any())
        {
            points++; // Increment points
            if (points > HighScore)
            {
                HighScore = points;
                PlayerPrefs.SetInt("HighScore", HighScore); // optional legacy use
                ScoreboardManager.Instance.AddScore(HighScore);
            }


            List<GameObject> boxesToDestroy = new List<GameObject>(BoxesObject);
            foreach (GameObject box in boxesToDestroy)
            {
                Destroy(box); // Destroy each box
            }
            // Optionally, you can clear the lists if needed after this
            BoxesObject.Clear();
            CurrentBoxes.Clear();

            GenerateNewCorrectBoxes();
        }
        if (points > HighScore)
        {
            HighScore = points;
            PlayerPrefs.SetInt("HighScore", HighScore); // Old method (keep if needed)

            // Add to scoreboard
            AddToScoreboard(playerName, HighScore);
            SaveScoreboard();
            UpdateScoreboardText();
            UpdateHighScoreText();
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BoxBrown"))
        {
            CurrentBoxes.Remove("BoxBrown");
            BoxesObject.Remove(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("BoxPink"))
        {
            CurrentBoxes.Remove("BoxPink");
            BoxesObject.Remove(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("BoxGreen"))
        {
            CurrentBoxes.Remove("BoxGreen");
            BoxesObject.Remove(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("BoxRed"))
        {
            CurrentBoxes.Remove("BoxRed");
            BoxesObject.Remove(collision.gameObject);
        }


    }


}

