using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text pointsText;
    public TMP_Text highScoreText;
    public void SetUp(int score, int highscore)
    {
        gameObject.SetActive(true);
        pointsText.text = "Score: " + score.ToString() + " Points";
        highScoreText.text = "High Score: " + highscore.ToString() + " Points";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Focus");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
