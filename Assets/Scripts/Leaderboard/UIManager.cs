using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text text;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    ScoreManager scoreManager;

    [SerializeField]
    LeaderboardManager leaderboardManager;
    public void AddUsername()
    {
        leaderboardManager.AddHighScore(text.text.ToString(), scoreManager.score);
    }

    public void AddScore(int amount)
    {
        scoreManager.score += amount;
    }

    public void ReduceScore(int amount)
    {
        scoreManager.score -= amount;
    }

    private void Update()
    {
        scoreText.text = "Score : " + scoreManager.score.ToString();
    }
}
