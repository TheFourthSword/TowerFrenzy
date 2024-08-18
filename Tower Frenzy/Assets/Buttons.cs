using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    //new public GameObject TutorialPanel;
    public void StartButton()
    {
        PlayerMovement.playing = true;
        PlayerTwoMovement.playing = true;
        BoxSpawner.playing = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitButton()
    {
        Debug.Log("Quitting the game");
        Application.Quit();
    }

    public void TutorialButton()
    {
       // TutorialPanel.gameObject.SetActive(true);
    }

    public void BackButton()
    {
       // TutorialPanel.gameObject.SetActive(false);
    }

    public void ReturnButton()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
