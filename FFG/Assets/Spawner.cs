using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject handPrefab;
    public int initialObstaclePoolSize = 10;
    private List<GameObject> obstaclePool;
    public float spawnDelay = 2f; // Delay between each spawn
    public float spawnHeight = 0f; // Height at which to spawn obstacles
    public float spawnDistance = 5f; // Distance between the last original object and the point where clones stop being generated
    private float nextSpawnTime;
    private GameObject lastObstacle;
    private int activeObjectsCount = 0; // The count of active objects in the hierarchy
    public float obstacleSpeed = 1f; // Initial speed of the obstacles
    public float speedIncreaseFactor = 0.0001f; // How much to increase the speed each time an obstacle is spawned

    void Start()
    {
        // Start the spawning coroutine with a delay
        StartCoroutine(StartSpawningWithDelay(spawnDelay));
    }

    IEnumerator StartSpawningWithDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Create the initial obstacle pool
        obstaclePool = new List<GameObject>();
        for (int i = 0; i < initialObstaclePoolSize; i++)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(spawnDelay);
        }

        // Start the hand spawning coroutine
        StartCoroutine(SpawnHands());
    }

    IEnumerator SpawnHands()
    {
        while (true)
        {
            // Wait for a random time between 10 and 15 seconds
            yield return new WaitForSeconds(Random.Range(10, 15));

            // Spawn between 1 and 3 hands
            int numHands = Random.Range(1, 4);
            for (int i = 0; i < numHands; i++)
            {
                SpawnHand();
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }

    void SpawnHand()
    {
        // Instantiate a new hand and set its position
        GameObject hand = Instantiate(handPrefab, new Vector3(transform.position.x, spawnHeight, transform.position.z), Quaternion.identity);

        // Add the hand to the obstacle pool
        obstaclePool.Add(hand);

        // Update the last obstacle and next spawn time
        lastObstacle = hand;
        nextSpawnTime = Time.time + spawnDelay;

        // Increase the count of active objects
        activeObjectsCount++;

        // Increase the speed of the obstacles
        obstacleSpeed += speedIncreaseFactor;
    }

    void Update()
    {
        // Check if it's time to spawn a new obstacle and if the last obstacle is far enough away
        if (Time.time > nextSpawnTime && lastObstacle != null && lastObstacle.transform.position.x - transform.position.x > spawnDistance)
        {
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        // Choose a random obstacle prefab
        int index = Random.Range(0, obstaclePrefabs.Length);
        GameObject obstaclePrefab = obstaclePrefabs[index];

        // Instantiate a new obstacle and set its position
        GameObject obstacle = Instantiate(obstaclePrefab, new Vector3(transform.position.x, spawnHeight, transform.position.z), Quaternion.identity);

        // Add the obstacle to the obstacle pool
        obstaclePool.Add(obstacle);

        // Update the last obstacle and next spawn time
        lastObstacle = obstacle;
        nextSpawnTime = Time.time + spawnDelay;

        // Increase the count of active objects
        activeObjectsCount++;

        // Increase the speed of the obstacles
        obstacleSpeed += speedIncreaseFactor;
    }

    // This method should be called when an obstacle is deactivated or destroyed
    public void OnObstacleDeactivated()
    {
        activeObjectsCount--;
    }
}