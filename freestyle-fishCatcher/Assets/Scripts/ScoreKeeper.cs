using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreKeeper : MonoBehaviour
{
    private static float score;  // everyone has the same score
    private static Text scoreText; // everyone has the same text

    // Use this for initialization
    internal void Start()
    {
        scoreText = GetComponent<Text>();
        UpdateText();

    }

    public static void AddToScore(float points)
    {
        score += points;
        UpdateText();
    }

    public static void resetScore()
    {
        score = 0 ;
        UpdateText();
    }

    private static void UpdateText()
    {
        if(score < 0)
        {
            score = 0;
        }
        scoreText.text = String.Format("Score: {0}", score);
    }
}
