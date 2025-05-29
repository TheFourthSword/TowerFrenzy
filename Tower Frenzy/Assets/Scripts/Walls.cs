using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{

    
    public List<GameObject> boxes = new List<GameObject>();
    public List<float> floats = new List<float>();


    private void Update()
    {
        for (int i = boxes.Count - 1; i >= 0; i--) // Reverse loop
        {
            floats[i] += Time.deltaTime;

            if (floats[i] >= 2f)
            {
                Debug.Log("Destroying box");
                Destroy(boxes[i]);
                boxes.RemoveAt(i);
                floats.RemoveAt(i);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BoxBrown"))
        {
            boxes.Add(collision.gameObject);
            floats.Add(0);
        }

        if (collision.gameObject.CompareTag("BoxPink"))
        {
            boxes.Add(collision.gameObject);
            floats.Add(0);
        }

        if (collision.gameObject.CompareTag("BoxRed"))
        {
            boxes.Add(collision.gameObject);
            floats.Add(0);
        }

        if (collision.gameObject.CompareTag("BoxGreen"))
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

    public void RemoveObject(GameObject _object)
    {
        int index = boxes.IndexOf(_object.gameObject);
        boxes.RemoveAt(index);
        floats.RemoveAt(index);
    }
}

