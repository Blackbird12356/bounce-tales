using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
}
