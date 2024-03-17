using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject handPrefab;
    public int initialObstaclePoolSize = 10;
    private List<GameObject> obstaclePool;
    private float spawnCooldown = 1.5f;
    public float spawnAcceleration = 0.1f;
    private float nextSpawnTime;
    public float spawnHeight = 0f;
    public float handSpawnHeight = 1f;

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

        // Start the hand spawning coroutine
        StartCoroutine(SpawnHands());
    }

    void Update()
    {
        // Check if it's time to spawn a new obstacle
        if (Time.time > nextSpawnTime)
        {
            // Spawn a new obstacle
            SpawnObstacle();

            // Decrease the spawn cooldown, but don't let it go below 0.5 seconds
            spawnCooldown = Mathf.Max(spawnCooldown - spawnAcceleration * Time.deltaTime, 0.5f);

            // Set the next spawn time
            nextSpawnTime = Time.time + spawnCooldown;
        }
    }

    void SpawnObstacle()
    {
        // Find an inactive obstacle in the pool
        GameObject obstacle = obstaclePool.Find(o => !o.activeInHierarchy);

        // If there are no inactive obstacles, create a new one
        if (obstacle == null)
        {
            // Choose a random obstacle prefab
            int index = Random.Range(0, obstaclePrefabs.Length);
            GameObject obstaclePrefab = obstaclePrefabs[index];

            obstacle = Instantiate(obstaclePrefab);
            obstaclePool.Add(obstacle);
        }

        // Activate the obstacle and set its position
        obstacle.SetActive(true);
        obstacle.transform.position = new Vector2(transform.position.x, spawnHeight);
    }

    IEnumerator SpawnHands()
    {
        while (true)
        {
            // Wait for a random time between 10 and 15 seconds
            yield return new WaitForSeconds(Random.Range(10f, 15f));

            // Spawn 1-3 hands
            int numHands = Random.Range(1, 4);
            for (int i = 0; i < numHands; i++)
            {
                SpawnHand();
            }
        }
    }

    void SpawnHand()
    {
        // Instantiate a new hand
        GameObject hand = Instantiate(handPrefab);

        // Set the hand's position
        float spawnX = transform.position.x;
        float spawnY = handSpawnHeight;
        hand.transform.position = new Vector2(spawnX, spawnY);
    }
}