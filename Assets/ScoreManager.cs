using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;
    public int diamondsToCollect = 6;
    public GameObject Block;

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScore();
        Debug.Log($"Собрано алмазов: {score}");

        if (score >= diamondsToCollect && Block != null)
        {         
            Block.SetActive(false);
            Debug.Log($"Блок исчез");
        }
    }

    public void UpdateScore()
    {
        if (scoreText != null)
            scoreText.text = score.ToString();
        else
            Debug.LogWarning("ScoreManager: поле Score Text не заполнено!");
    }
}
