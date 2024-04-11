using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Required for TextMeshPro

public class TimeDisplay : MonoBehaviour
{
    public TextMeshProUGUI timeText; // Reference to the TextMeshProUGUI component for the time

    private float timeElapsed = 0f; // Time elapsed since the start of the game
    private bool isPaused = false; // Whether the game is paused

    // Start is called before the first frame update
    void Start()
    {
        // Check if timeText is not null
        if (timeText != null)
        {
            // Set the color of the time text to black
            timeText.color = Color.black;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            // Increase the time elapsed
            timeElapsed += UnityEngine.Time.deltaTime;

            // Convert the time elapsed to TimeSpan
            System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(timeElapsed);

            // Update the time text if it's not null
            if (timeText != null)
            {
                // Format the time as 00:00
                timeText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
            }
        }
    }
}