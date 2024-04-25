using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class Replay : MonoBehaviour
{
    public AudioSource audioSource; // The AudioSource component

    // Start is called before the first frame update
    void Start()
    {
        // Play the game over sound
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the space key was pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Resume the game at normal speed
            Time.timeScale = 1;
            // Load the GameScene
            SceneManager.LoadScene("GameScene");
        }
    }
}