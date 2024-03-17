using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleMOVEMENT : MonoBehaviour
{
    public float speed = 10f;
    public float acceleration = 0.01f;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        speed += acceleration * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            Destroy(player);
            // Stop the game
            Time.timeScale = 0;
        }
    }
}