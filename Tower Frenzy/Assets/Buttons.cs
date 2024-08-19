using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    new public GameObject CurrentPanel;
    new public GameObject NextPanel;
    public void StartButton()
    {
        Debug.Log("help");
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

    public void PanelButton()
    {
        CurrentPanel.gameObject.SetActive(false);
        NextPanel.gameObject.SetActive(true);
    }

    public void EndButton()
    {
        SceneManager.LoadScene("EndScreen");
    }

    public void Multiplayer()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void NextButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
