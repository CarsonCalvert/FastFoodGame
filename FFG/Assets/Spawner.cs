using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public GameObject handPrefab; // Commented out
    public GameObject cloudPrefab; 
    public GameObject[] obstaclePrefabs;
    public float spawnHeight = 0f;
    //public float handSpawnHeight = 0f; // Commented out
    public float obstacleSpeed = 0f;
    public float spawnDelay = 0f;
    //public float handSpawnDelay = 0f; // Commented out

    void Start()
    {
        //StartCoroutine(SpawnHands()); // Commented out
        StartCoroutine(StartCloudsAfterDelay(0.1f));
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator StartCloudsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(SpawnClouds());
    }

IEnumerator SpawnClouds()
{
    while (true)
    {
        Debug.Log("Spawning cloud...");
        GameObject cloud = Instantiate(cloudPrefab);
        if (cloud != null)
        {
            cloud.transform.position = new Vector3(transform.position.x, 4f, transform.position.z);
        }
        else
        {
            Debug.LogWarning("Cloud not instantiated");
        }
        yield return new WaitForSeconds(3f);
    }
}
    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            Debug.Log("Spawning obstacle...");
            GameObject obstacle = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)]);
            obstacle.transform.position = new Vector3(transform.position.x, spawnHeight, transform.position.z);
            Rigidbody2D rb = obstacle.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(-obstacleSpeed, 0);
            }
            else
            {
                Debug.LogWarning("Obstacle does not have a Rigidbody2D component");
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    /* Commented out
    IEnumerator SpawnHands()
    {
        while (true)
        {
            Debug.Log("Spawning hand...");
            GameObject hand = Instantiate(handPrefab);
            hand.transform.position = new Vector3(transform.position.x, handSpawnHeight, transform.position.z);
            Rigidbody2D rb = hand.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(-obstacleSpeed, 0);
            }
            else
            {
                Debug.LogWarning("Hand does not have a Rigidbody2D component");
            }
            yield return new WaitForSeconds(handSpawnDelay);
        }
    }
    */
}