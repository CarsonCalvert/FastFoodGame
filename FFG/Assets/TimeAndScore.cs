using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Required for TextMeshPro

public class TimeAndScore : MonoBehaviour
{
    public TextMeshProUGUI timeAndScoreText; // Reference to the TextMeshProUGUI component
    private float timeElapsed = 0f; // Time elapsed since the start of the game
    private int score = 0; // Player's score
    private bool isPaused = false; // Whether the game is paused

    // Start is called before the first frame update
    void Start()
    {
        if (timeAndScoreText != null) // Check if timeAndScoreText is not null
        {
            // Set the color of the text to black
            timeAndScoreText.color = Color.black;
        }
        else
        {
            Debug.LogError("timeAndScoreText is not assigned in the inspector");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            // Increase the time elapsed
            timeElapsed += Time.deltaTime;

            // Increase the score by 1000 every second
            score += (int)(1000 * Time.deltaTime);

            // Convert the time elapsed to minutes and seconds
            int minutes = (int)timeElapsed / 60;
            int seconds = (int)timeElapsed % 60;

            // Update the text
            if (timeAndScoreText != null) // Check if timeAndScoreText is not null
            {
                timeAndScoreText.text = string.Format("{0:00}:{1:00} / {2:N0}", minutes, seconds, score);
            }
        }
        else
        {
            // If the game is paused, show the score
            if (timeAndScoreText != null) // Check if timeAndScoreText is not null
            {
                timeAndScoreText.text = string.Format("Score: {0:N0}", score);
            }
        }
    }

    // Call this method to increase the score
    public void IncreaseScore(int amount)
    {
        score += amount;
    }

    // Call this method to pause or unpause the game
    public void TogglePause()
    {
        isPaused = !isPaused;
    }
}