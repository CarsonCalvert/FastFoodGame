using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class ObsticleMOVEMENT : MonoBehaviour
{
    public bool isCloud = false;
    private GameObject player;
    private TerrainSpeed terrainSpeed; // Reference to the TerrainSpeed script
    private float speedMultiplier = 9f; // Adjust this value to get the desired speed

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        terrainSpeed = GameObject.FindGameObjectWithTag("Terrain").GetComponent<TerrainSpeed>(); // Get the TerrainSpeed script from the terrain GameObject
    }

    // LateUpdate is called after all Update methods have been called
    void LateUpdate()
    {
        float speed = terrainSpeed.AnimatorSpeed * speedMultiplier; // Get the speed from the TerrainSpeed script and multiply it by the speedMultiplier
        Debug.Log("Obstacle speed: " + speed); // Log the speed
        transform.position += Vector3.left * speed * Time.deltaTime; // Use the speed variable to move the obstacle
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player && gameObject.tag == "ObjectToBeDeleted" && !isCloud)
        {
            Destroy(player);
            // Stop the game
            Time.timeScale = 0;
            // Load the game over screen
            // Replace "GameOver" with the name of your game over scene
            SceneManager.LoadScene("GameOver");
        }
    }
}