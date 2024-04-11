using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Load the game scene
            // Replace "GameScene" with the name of your game scene
            SceneManager.LoadScene("GameScene");
        }
    }
}