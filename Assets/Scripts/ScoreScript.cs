using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;

    public int score, highScore;

    [SerializeField] TextMeshProUGUI  scoreText;
    [SerializeField] TextMeshProUGUI  highScoreText;
    [SerializeField] static bool InstanceExists = false;

    void Awake() {
        if(instance == null) //&& !InstanceExists)
        {
        DontDestroyOnLoad(this);
        instance = this;
        InstanceExists = true;
        }
    }

    public void AddScore()
    {
        score++;

        //UpdateHighScore;

        scoreText.text = score.ToString();  

    }

    public void UpdateHighScore()
    {
        if(score > highScore)
        {
            highScore = score;

            highScoreText.text = highScore.ToString();

            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    /*public void ResetScore()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
    */
}
