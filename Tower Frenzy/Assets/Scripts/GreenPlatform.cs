using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GreenPlatform : MonoBehaviour
{
    public int points;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BoxGreen"))
        {
            points++;
        }
        if (collision.gameObject.CompareTag("BoxSpecial"))
        {
            points += 2;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BoxGreen"))
        {
            points--;
        }
        if (collision.gameObject.CompareTag("BoxSpecial"))
        {
            points -= 2;
        }
    }
}
