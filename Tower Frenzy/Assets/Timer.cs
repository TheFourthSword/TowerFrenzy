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
    public PointDisplay counter1;
    public PointDisplayTwo counter2;
    new public GameObject OneWins;
    new public GameObject TwoWins;
    new public GameObject Tie;


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
            StartCoroutine(WhoWon());
            //SceneManager.LoadScene("LastScene");
        }
    }

    IEnumerator WhoWon()
    {
        PlayerMovement.playing = false;
        PlayerTwoMovement.playing = false;
        BoxSpawner.playing = false;

        if (counter1.count < counter2.count)
        {
            OneWins.gameObject.SetActive(true);
        }
        
        else if (counter1.count > counter2.count)
        {
            TwoWins.gameObject.SetActive(true);
        }

        else if (counter1.count == counter2.count)
        {
            Tie.gameObject.SetActive(true);
        }
        yield return null;
    }
}
