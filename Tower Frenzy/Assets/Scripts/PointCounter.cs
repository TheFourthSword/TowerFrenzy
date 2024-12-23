 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;

public class PointCounter : MonoBehaviour
{

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
        GenerateNewCorrectBoxes();
        // BoxesList = new List<GameObject>(Resources.LoadAll<GameObject>("Boxes"));
     /*   for (int i = 0; i < PossibleBoxes.Count-2; i++)
        {
            CorrectBoxes.Add(PossibleBoxes[Random.Range(0, PossibleBoxes.Count)]);
        } */
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

        if (CorrectBoxes.OrderBy(x => x).SequenceEqual(CurrentBoxes.OrderBy(x => x)))
        {
            points++; // Increment points
            if (points > HighScore)
            {
                HighScore = points;
                PlayerPrefs.SetInt("HighScore", HighScore); // Save the new high score
                UpdateHighScoreText(); // Update the displayed high score
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

        //if (collision.gameObject.CompareTag("BoxSpecial"))
        // {
        //     points += 2;
        // }

        /* if (CorrectBoxes == CurrentBoxes)
         {
             points++;
             foreach (GameObject box in BoxesObject)
             {
                 Destroy(box);
             }
             //StartCoroutine(CleanUp());
             //StopCoroutine(CleanUp());
         } */
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BoxBrown"))
        {
           // points--;
            CurrentBoxes.Remove("BoxBrown");
            BoxesObject.Remove(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("BoxPink"))
        {
            //points--;
            CurrentBoxes.Remove("BoxPink");
            BoxesObject.Remove(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("BoxGreen"))
        {
            //points--;
            CurrentBoxes.Remove("BoxGreen");
            BoxesObject.Remove(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("BoxRed"))
        {
            //points--;
            CurrentBoxes.Remove("BoxRed");
            BoxesObject.Remove(collision.gameObject);
        }

       // if (collision.gameObject.CompareTag("BoxSpecial"))
       // {
       //     points -= 2;
      //  }

    }

  //  IEnumerator CleanUp()
 //   {
 //       yield return new WaitForSeconds(1);
  //      Destroy(gameObject);
  //      CurrentBoxes.Clear();
  //  }

}
