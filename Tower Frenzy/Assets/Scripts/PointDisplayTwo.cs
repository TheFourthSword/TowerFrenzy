using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointDisplayTwo : MonoBehaviour
{
    public Text pointTextTwo;
    public int count;
    public PointCounter pointCounter;
    public float currentPointsTwo;

    // Start is called before the first frame update
    void Start()
    {
        //pointText = GetComponent<Text>();
        currentPointsTwo = count;
    }

    // Update is called once per frame
    void Update()
    {
        pointTextTwo.text = count.ToString();
        count = pointCounter.points;
    }
}
