 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{

    public int points;
   [SerializeField] public List<string> PossibleBoxes = new List<string>() { "BoxBrown", "BoxPink", "BoxGreen", "BoxRed" };
   [SerializeField] public List<string> CorrectBoxes = new List<string>() { };
    public List<string> CurrentBoxes = new List<string>();
    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < PossibleBoxes.Count-1; i++)
        {
            CorrectBoxes.Add(PossibleBoxes[Random.Range(0, PossibleBoxes.Count)]);
        }
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BoxBrown"))
        {
            points++;
            CurrentBoxes.Add("BoxBrown");
        }
        if (collision.gameObject.CompareTag("BoxSpecial"))
        {
            points += 2;
        }
        if (CorrectBoxes == CurrentBoxes)
        {

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BoxBrown"))
        {
            points--;
            CurrentBoxes.Remove("BoxBrown");
        }
        if (collision.gameObject.CompareTag("BoxSpecial"))
        {
            points -= 2;
        }
    }

}
