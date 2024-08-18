using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointDisplay : MonoBehaviour
{
    public Text pointText;
    public int count;
    public PointCounter pointCounter;
    public float currentPoints;

    // Start is called before the first frame update
    void Start()
    {
        //pointText = GetComponent<Text>();
        currentPoints = count;
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = count.ToString();
        count = pointCounter.points;
    }
}
