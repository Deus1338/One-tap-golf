using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

    [SerializeField] TextMeshProUGUI scoreTextInGame;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    public int score = 0;
    private int highScore;

    LevelInfo levelInfo;

    private void Start()
    {
        levelInfo = FindObjectOfType<LevelInfo>();
        scoreText.text = "Score: " + score.ToString();
    }

    private void Update()
    {
        if (levelInfo.menuIsInstantiated == false)
        {
            scoreTextInGame.text = score.ToString();
        }

    }

    //Adding a point and storing highscore if needed
    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        }

    }

    //Resets the high score
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteAll();
        highScoreText.text = "High Score: 0";
    }



}
