using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    public int score = 0;
    public int highscore = 0;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "High Score: " + highscore.ToString();
    }

    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();

        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
            highScoreText.text = "High Score: " + highscore.ToString();
        }
    }
}
