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
        Debug.Log($"������� �������: {score}");

        if (score >= diamondsToCollect && Block != null)
        {         
            Block.SetActive(false);
            Debug.Log($"���� �����");
        }
    }

    public void UpdateScore()
    {
        if (scoreText != null)
            scoreText.text = score.ToString();
        else
            Debug.LogWarning("ScoreManager: ���� Score Text �� ���������!");
    }
}
