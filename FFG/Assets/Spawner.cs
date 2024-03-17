using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public int initialObstaclePoolSize = 10;
    private List<GameObject> obstaclePool;
    private float spawnCooldown = 2f;
    private float nextSpawnTime;
    public float spawnHeight = 0f;

    void Start()
    {
        // Create the initial obstacle pool
        obstaclePool = new List<GameObject>();
        for (int i = 0; i < initialObstaclePoolSize; i++)
        {
            // Choose a random obstacle prefab
            int index = Random.Range(0, obstaclePrefabs.Length);
            GameObject obstaclePrefab = obstaclePrefabs[index];

            GameObject obstacle = Instantiate(obstaclePrefab);
            obstacle.SetActive(false);
            obstaclePool.Add(obstacle);
        }

        // Spawn the first clone immediately
        SpawnObstacle();

        // Set the next spawn time to 2 seconds from now
        nextSpawnTime = Time.time + spawnCooldown;
    }

    void Update()
    {
        // Check if it's time to spawn a new obstacle
        if (Time.time > nextSpawnTime)
        {
            // Spawn a new obstacle
            SpawnObstacle();

            // Set the next spawn time to a random number of seconds from now
            nextSpawnTime = Time.time + Random.Range(2f, 5f);
        }

        // Deactivate obstacles that have moved off the screen
        foreach (GameObject obstacle in obstaclePool)
        {
            if (obstacle.activeInHierarchy && obstacle.transform.position.x < Camera.main.transform.position.x - Camera.main.orthographicSize * Screen.width / Screen.height)
            {
                obstacle.SetActive(false);
            }
        }
    }

    void SpawnObstacle()
    {
        // Choose a random obstacle prefab
        int index = Random.Range(0, obstaclePrefabs.Length);
        GameObject obstaclePrefab = obstaclePrefabs[index];

        // Find an inactive obstacle in the pool or create a new one if none are available
        GameObject obstacle = obstaclePool.Find(o => !o.activeInHierarchy);
        if (obstacle == null)
        {
            obstacle = Instantiate(obstaclePrefab);
            obstaclePool.Add(obstacle);
        }

        // Calculate the spawn position
        float spawnPositionX = transform.position.x + Random.Range(1.5f, 3f) * obstacle.transform.localScale.x;
        float spawnPositionY = spawnHeight; // Use the fixed height here
        Vector3 spawnPosition = new Vector3(spawnPositionX, spawnPositionY, 0);

        // Activate the obstacle and move it to the spawn position
        obstacle.transform.position = spawnPosition;
        obstacle.SetActive(true);
    }
}