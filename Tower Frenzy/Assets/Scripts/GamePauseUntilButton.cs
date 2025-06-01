using UnityEngine;
using UnityEngine.UI;

public class GamePauseUntilButton : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button continueButton;

    private void Start()
    {
        // Pause the game
        Time.timeScale = 0f;

        // Make sure the panel is active
        if (pausePanel != null)
            pausePanel.SetActive(true);

        // Set up the button click listener
        if (continueButton != null)
            continueButton.onClick.AddListener(UnpauseGame);
    }

    private void UnpauseGame()
    {
        // Unpause the game
        Time.timeScale = 1f;

        // Hide the panel
        if (pausePanel != null)
            pausePanel.SetActive(false);
    }
}

