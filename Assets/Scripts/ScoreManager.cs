using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public int score, highscore, autosaveTimer;
    public Text scoreText;
    void Start()
    {   if (PlayerPrefs.HasKey("highscore") == false)
            highscore = 0;
        else
            highscore = PlayerPrefs.GetInt("highscore");
    }
    void Update()
    {
        if (score > highscore)
            highscore = score;
        if (score < 0)
            score = 0;
        PlayerPrefs.SetInt("highscore", highscore);
        scoreText.text = string.Format($"Score: {score}\nHighscore: {highscore}");
        autosaveTimer++;
        if (autosaveTimer >= 5000)
        {
            autosaveTimer = 0;
            PlayerPrefs.Save();
            print("Saving...");
        }
    }
    public void AddScore(int amount)
    {
        score += amount;
    }
    public void DetractScore(int amount)
    {
        score -= amount;
    }
}