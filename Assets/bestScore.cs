using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bestScore : MonoBehaviour
{
    public static int points = 0;
    Text score;
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "best score: " + points;
    }

    public static void updateScore(int pointsTmp)
    {
        if (points < pointsTmp)
            points = pointsTmp;

    }
}
