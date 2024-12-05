using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{

    public int points;
   [SerializeField] public List<string> CorrectBoxes = new List<string>() { "BoxBrown", "BoxPink", "BoxGreen", "BoxRed" };
    public List<string> CurrentBoxes = new List<string>();
    

    // Start is called before the first frame update
    void Start()
    {
        
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
        }
        if (collision.gameObject.CompareTag("BoxSpecial"))
        {
            points -= 2;
        }
    }

}
