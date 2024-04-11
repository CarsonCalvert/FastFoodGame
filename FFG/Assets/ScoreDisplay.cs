using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private float score = 0; // The current score
    private float highScore = 0; // The high score
    private bool isPaused = false; // Whether the score counting is paused

    void Start()
    {
        // Load the high score from PlayerPrefs
        highScore = PlayerPrefs.GetFloat("HighScore", 0);

        // Update the high score text
        if (highScoreText != null)
        {
            highScoreText.text = Mathf.Round(highScore).ToString();
        }
    }

    void Update()
    {
        if (!isPaused)
        {
            // Increase the score
            score += Time.deltaTime * 1000;

            // Update the score text if it's not null
            if (scoreText != null)
            {
                scoreText.text = Mathf.Round(score).ToString();
            }

            // Check if the current score is higher than the high score
            if (score > highScore)
            {
                // Update the high score
                highScore = score;

                // Save the high score to PlayerPrefs
                PlayerPrefs.SetFloat("HighScore", highScore);

                // Update the high score text
                if (highScoreText != null)
                {
                    highScoreText.text = Mathf.Round(highScore).ToString();
                }
            }
        }
    }
}