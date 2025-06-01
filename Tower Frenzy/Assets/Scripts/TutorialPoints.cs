using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;


public class TutorialPoints : MonoBehaviour
{
    public int points;
    public int level = 1;
    private int phase = 1; // Phase 1: single box, Phase 2: two boxes

    [SerializeField] public List<string> PossibleBoxes = new List<string>() { "BoxBrown", "BoxPink", "BoxGreen", "BoxRed" };
    [SerializeField] public List<string> CorrectBoxes = new List<string>() { };

    public List<GameObject> BoxesObject = new List<GameObject>();
    public List<string> CurrentBoxes = new List<string>();

    [SerializeField] private Text feedbackText;
    [SerializeField] private GameObject okPanel; // UI panel with OK sprite
    [SerializeField] private float okDisplayDuration = 1.0f;
    [SerializeField] private GameObject tutPanel;

    private bool isTransitioning = false;

    void Start()
    {
        GenerateNewCorrectBoxes();
        UpdateFeedbackText();
    }

    private void UpdateFeedbackText()
    {
        feedbackText.text = "Stack these boxes: \n";
        foreach (string box in CorrectBoxes)
        {
            feedbackText.text += box + "\n";
        }
    }

    private void GenerateNewCorrectBoxes()
    {
        CorrectBoxes.Clear();

        int numBoxes = (phase == 1) ? 1 : 2;

        List<string> shuffled = PossibleBoxes.OrderBy(x => Random.value).ToList();
        for (int i = 0; i < numBoxes && i < shuffled.Count; i++)
        {
            CorrectBoxes.Add(shuffled[i]);
        }

        CurrentBoxes.Clear();
        UpdateFeedbackText();
    }

    private IEnumerator ShowOkThenNextPhase()
    {
        isTransitioning = true;

        // Show OK panel after successful box placement
        okPanel.SetActive(true);
        yield return new WaitForSeconds(okDisplayDuration);
        okPanel.SetActive(false);

        if (phase == 1)
        {
            // Move to Phase 2 in the same scene
            phase = 2;
            GenerateNewCorrectBoxes();
            isTransitioning = false;
        }
        else
        {
            // After Phase 2, load next scene
            yield return new WaitForSeconds(0.5f); // Small pause before final OK flash

            tutPanel.SetActive(true);
            yield return new WaitForSeconds(okDisplayDuration);
            tutPanel.SetActive(false);

            // Load the next scene in the build order
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }
    }


    private bool IsCorrect()
    {
        return !CorrectBoxes.Except(CurrentBoxes).Any() && !CurrentBoxes.Except(CorrectBoxes).Any();
    }

    private void CheckBoxes()
    {
        if (CurrentBoxes.Count == CorrectBoxes.Count && IsCorrect())
        {
            points++;

            // Only destroy correct boxes
            foreach (var box in new List<GameObject>(BoxesObject))
            {
                Destroy(box);
            }
            BoxesObject.Clear();
            CurrentBoxes.Clear();

            StartCoroutine(ShowOkThenNextPhase());
        }
        else if (CurrentBoxes.Count == CorrectBoxes.Count)
        {
           // feedbackText.text = "Incorrect. Try again.";
          //  StartCoroutine(ClearFeedbackAfterDelay(2f));

            // Do NOT destroy boxes
         //   CurrentBoxes.Clear();
          //  BoxesObject.Clear(); // Optional: clear reference, but not destroy actual objects
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTransitioning) return;

        string boxTag = collision.gameObject.tag;
        if (PossibleBoxes.Contains(boxTag) && !CurrentBoxes.Contains(boxTag))
        {
            CurrentBoxes.Add(boxTag);

            // Only track the box if it is correct
            if (CorrectBoxes.Contains(boxTag))
            {
                BoxesObject.Add(collision.gameObject);
            }
        }

        CheckBoxes();
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        string boxTag = collision.gameObject.tag;
        if (CurrentBoxes.Contains(boxTag))
        {
            CurrentBoxes.Remove(boxTag);
            BoxesObject.Remove(collision.gameObject);
        }
    }
  //  private IEnumerator ClearFeedbackAfterDelay(float delay)
   // {
  //      yield return new WaitForSeconds(delay);
  //      UpdateFeedbackText(); // Re-show original prompt
   // }


    void Update()
    {
        // Optional debug for phase state
        // Debug.Log($"Level: {level}, Phase: {phase}");
    }
}

