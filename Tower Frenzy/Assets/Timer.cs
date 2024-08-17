using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public float MaxTime;
    public bool timerIsRunning = false;
    public Text timeText;
   //public PlayerMovement PlayerMovement;
    public float currentTime;


    private void Start()
    {
        currentTime = MaxTime;
        DisplayTime(currentTime);
        // Starts the timer automatically
        timerIsRunning = true;
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void Update()
    {
        DisplayTime(currentTime);

        if (timerIsRunning)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                currentTime = 0;
                timerIsRunning = false;
            }
        }
        if (timerIsRunning == false)
        {
            SceneManager.LoadScene("LastScene");
        }
    }
}
