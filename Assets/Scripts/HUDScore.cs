using TMPro;
using UnityEngine;

public class HUDScore : MonoBehaviour
{
    TMP_Text scoreText;

    void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    void OnEnable()
    {
        GameManager.OnScoreChange += UpdateScore;
    }

    void OnDisable()
    {
        GameManager.OnScoreChange += UpdateScore;
    }

    void UpdateScore(int score)
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString();
    }
}
