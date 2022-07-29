using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scores : MonoBehaviour
{
    private static int BestScore;

    int score = 0;

    [SerializeField]
    private TextMesh ActualscoreText;

    [SerializeField]
    private TextMesh BestscoreText;

    private void Awake()
    {
        BestScore = PlayerPrefs.GetInt("highscore", BestScore);
        BestscoreText.text = "Best Score: " + BestScore;
        ActualscoreText.text = "Points: " + score;
    }
    public void AddScore()
    {
        score += 50;
        ActualscoreText.text = "Points: " + score;
    }

    public void SaveScore()
    {
        if(score > BestScore)
        {
            BestScore = score; 
            PlayerPrefs.SetInt("highscore", BestScore);
            PlayerPrefs.Save();
        }
    }

}
