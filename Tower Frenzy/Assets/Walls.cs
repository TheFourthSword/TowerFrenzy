using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public List<GameObject> boxes = new List<GameObject>();
    public List<float> floats = new List<float>();


    private void Update()
    {
        for (int i = 0; i < boxes.Count; i++)
        {
            floats[i] += 1 * Time.deltaTime;

            if (floats[i] >= 5f)
            {
                Debug.Log("Please");
                int index = boxes.IndexOf(boxes[i]);
                boxes.RemoveAt(index);
                floats.RemoveAt(index);
                Destroy(boxes[i]);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            boxes.Add(collision.gameObject);
            floats.Add(0);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
            int index = boxes.IndexOf(collision.gameObject);
            boxes.RemoveAt(index);
            floats.RemoveAt(index);
    }
}
